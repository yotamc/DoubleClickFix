// Copyright (C) 2020 Yotam Cohen
//
// This file is part of DoubleClickFix.
//
// DoubleClickFix is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DoubleClickFix is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DoubleClickFix.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DoubleClickFix
{
    public class MouseEventBlocker
    {
        private readonly Dictionary<Win32.MouseInputNotification, uint> _lastEventTimes = new Dictionary<Win32.MouseInputNotification, uint>();
        public IEnumerable<Win32.MouseInputNotification> Events => _lastEventTimes.Keys;
        public uint Threshold { get; set; }

        private readonly Win32.LowLevelMouseProc _proc;
        private IntPtr _hookPtr = IntPtr.Zero;

        public event EventHandler<MouseEventArgs> EventHandled;

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

        protected virtual void OnEventHandled(MouseEventArgs e)
        {
            EventHandled?.Invoke(this, e);
        }

        private IntPtr HookCallback(int nCode, Win32.MouseInputNotification wParam, Win32.MSLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0 && _lastEventTimes.ContainsKey(wParam))
            {
                var timeDiff = lParam.time - _lastEventTimes[wParam];
                var shouldBlock = timeDiff < Threshold;
                
                OnEventHandled(new MouseEventArgs
                {
                    Timestamp = lParam.time,
                    TimeDiff = timeDiff,
                    MouseEvent = wParam,
                    IsBlocked = shouldBlock,
                    X = lParam.pt.x,
                    Y = lParam.pt.y
                });

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