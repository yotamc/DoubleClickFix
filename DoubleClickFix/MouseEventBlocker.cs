using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DoubleClickFix
{
    public class MouseEventBlocker : IEventBlocker<Win32.MouseInputNotification>
    {
        private Dictionary<Win32.MouseInputNotification, uint> _lastEventTimes = new Dictionary<Win32.MouseInputNotification, uint>();
        public IEnumerable<Win32.MouseInputNotification> Events => _lastEventTimes.Keys;
        public uint Threshold { get; set; }

        private Win32.LowLevelMouseProc _proc;
        private IntPtr _hookPtr = IntPtr.Zero;

        public MouseEventBlocker()
        {
            _proc = HookCallback;
        }

        public void Register(Win32.MouseInputNotification value)
        {
            _lastEventTimes[value] = 0;
        }

        public void Unregister(Win32.MouseInputNotification value)
        {
            _lastEventTimes.Remove(value);
        }

        public void Start()
        {
            if (_hookPtr != IntPtr.Zero)
                throw new InvalidOperationException();

            _hookPtr = Win32.SetWindowsHookEx(Win32.HookType.WH_MOUSE_LL, _proc, Win32.GetModuleHandle("user32"), 0);
            if (_hookPtr == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void Stop()
        {
            if (_hookPtr == IntPtr.Zero)
                throw new InvalidOperationException();

            Win32.UnhookWindowsHookEx(_hookPtr);
            _hookPtr = IntPtr.Zero;
        }

        private IntPtr HookCallback(int nCode, Win32.MouseInputNotification wParam, Win32.MSLLHOOKSTRUCT lParam)
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
            return Win32.CallNextHookEx(_hookPtr, nCode, wParam, lParam);
        }
    }
}