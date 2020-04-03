using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DoubleClickFix
{
    class MouseEventBlocker
    {
        //TODO make these configurable
        private const int MinTimeDifference = 125;
        private Dictionary<MouseMessages, uint> _lastEventTimes = new Dictionary<MouseMessages, uint>{
            {MouseMessages.WM_LBUTTONDOWN, 0},
            {MouseMessages.WM_LBUTTONUP, 0}
        };

        private delegate IntPtr LowLevelMouseProc(int nCode, MouseMessages wParam, MSLLHOOKSTRUCT lParam);
        private IntPtr _hookId = IntPtr.Zero;

        public void Hook()
        {
            if (_hookId != IntPtr.Zero)
                throw new InvalidOperationException();

            _hookId = SetHook(HookCallback);
        }

        public void Unhook()
        {
            if (_hookId == IntPtr.Zero)
                throw new InvalidOperationException();

            UnhookWindowsHookEx(_hookId);
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            IntPtr hook = SetWindowsHookEx(HookType.WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
            if (hook == IntPtr.Zero)
                throw new Win32Exception();
            return hook;
        }

        private IntPtr HookCallback(int nCode, MouseMessages wParam, MSLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0 && _lastEventTimes.ContainsKey(wParam))
            {
                var timeDiff = lParam.time - _lastEventTimes[wParam];
                var shouldBlock = timeDiff < MinTimeDifference;
                Console.WriteLine($"{lParam.time} (d:{timeDiff}ms) {wParam} {(shouldBlock ? "BLOCKED" : "OK")}: x:{lParam.pt.x} y:{lParam.pt.y}");
                if (shouldBlock)
                {
                    return new IntPtr(1);
                }

                _lastEventTimes[wParam] = lParam.time;
            }
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private enum HookType : int
        {
            WH_MOUSE_LL = 14
        }

        private enum MouseMessages : int
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
            MouseMessages wParam, MSLLHOOKSTRUCT lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}