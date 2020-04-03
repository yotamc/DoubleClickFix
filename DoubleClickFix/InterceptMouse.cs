using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DoubleClickFix
{
    class InterceptMouse
    {
        private const int MinTimeDifference = 125;
        private delegate IntPtr LowLevelMouseProc(int nCode, MouseMessages wParam, IntPtr lParam);

        private Dictionary<MouseMessages, uint> _lastEventTimes = new Dictionary<MouseMessages, uint>();

        private LowLevelMouseProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public InterceptMouse()
        {
            _proc = HookCallback;

            //TODO make this configurable
            _lastEventTimes[MouseMessages.WM_LBUTTONDOWN] = 0;
            _lastEventTimes[MouseMessages.WM_LBUTTONUP] = 0;
        }

        public void Hook()
        {
            _hookID = SetHook(_proc);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            IntPtr hook = SetWindowsHookEx(HookType.WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
            if (hook == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            return hook;
            // using (Process curProcess = Process.GetCurrentProcess())
            // using (ProcessModule curModule = curProcess.MainModule)
            // {
            //     return SetWindowsHookEx(HookType.WH_MOUSE_LL, proc,
            //         GetModuleHandle(curModule.ModuleName), 0);
            // }
        }

        private IntPtr HookCallback(int nCode, MouseMessages wParam, IntPtr lParam)
        {
            if (nCode >= 0 && _lastEventTimes.ContainsKey(wParam))
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                var timeDiff = hookStruct.time - _lastEventTimes[wParam];
                var shouldBlock = timeDiff < MinTimeDifference;
                Console.WriteLine($"{hookStruct.time} (d:{timeDiff}ms) {wParam} {(shouldBlock ? "BLOCKED" : "OK")}: x:{hookStruct.pt.x} y:{hookStruct.pt.y}");
                if (shouldBlock)
                {
                    return new IntPtr(1);
                }

                _lastEventTimes[wParam] = hookStruct.time;
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
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
            MouseMessages wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}