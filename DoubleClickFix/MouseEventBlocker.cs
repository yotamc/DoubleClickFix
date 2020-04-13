using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DoubleClickFix
{

    public class MouseEventBlocker : IEventBlocker<MouseEvent>
    {
        public uint Threshold { get; set; } = 125;
        private Dictionary<MouseInputNotification, uint> _lastEventTimes = new Dictionary<MouseInputNotification, uint>();
        private static readonly Dictionary<MouseEvent, IEnumerable<MouseInputNotification>> _mouseEventsMap = new Dictionary<MouseEvent, IEnumerable<MouseInputNotification>>
        {
            { MouseEvent.LeftMouseButton, new[] { MouseInputNotification.WM_LBUTTONDOWN, MouseInputNotification.WM_LBUTTONUP } }
        };
        private delegate IntPtr LowLevelMouseProc(int nCode, MouseInputNotification wParam, MSLLHOOKSTRUCT lParam);
        private LowLevelMouseProc _proc;
        private IntPtr _hookPtr = IntPtr.Zero;

        public MouseEventBlocker()
        {
            _proc = HookCallback;
        }

        public void Register(MouseEvent value)
        {
            if (_mouseEventsMap.TryGetValue(value, out var collection))
            {
                foreach (var obj in collection)
                    _lastEventTimes[obj] = 0;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Unegister(MouseEvent value)
        {
            if (_mouseEventsMap.TryGetValue(value, out var collection))
            {
                foreach (var obj in collection)
                    _lastEventTimes.Remove(obj);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Start()
        {
            if (_hookPtr != IntPtr.Zero)
                throw new InvalidOperationException();

            _hookPtr = SetWindowsHookEx(HookType.WH_MOUSE_LL, _proc, GetModuleHandle("user32"), 0);
            if (_hookPtr == IntPtr.Zero)
                throw new Win32Exception();
        }

        public void Stop()
        {
            if (_hookPtr == IntPtr.Zero)
                throw new InvalidOperationException();

            UnhookWindowsHookEx(_hookPtr);
            _hookPtr = IntPtr.Zero;
        }

        private IntPtr HookCallback(int nCode, MouseInputNotification wParam, MSLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0 && _lastEventTimes.ContainsKey(wParam))
            {
                var timeDiff = lParam.time - _lastEventTimes[wParam];
                var shouldBlock = timeDiff < Threshold;
                Console.WriteLine($"{lParam.time} (d:{timeDiff}ms) {wParam} {(shouldBlock ? "BLOCKED" : "OK")}: x:{lParam.pt.x} y:{lParam.pt.y}");
                if (shouldBlock)
                {
                    return new IntPtr(1);
                }

                _lastEventTimes[wParam] = lParam.time;
            }
            return CallNextHookEx(_hookPtr, nCode, wParam, lParam);
        }

        #region Win32 API
        private enum HookType : int
        {
            WH_MOUSE_LL = 14
        }

        // https://docs.microsoft.com/en-us/windows/win32/inputdev/mouse-input-notifications
        private enum MouseInputNotification : int
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEHWHEEL = 0x020E,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(HookType idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            MouseInputNotification wParam, MSLLHOOKSTRUCT lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
}