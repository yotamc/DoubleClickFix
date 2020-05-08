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

using DoubleClickFix.View;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DoubleClickFix.Presenter
{
    public class MainPresenter
    {
        private const int DebugLogMaxLines = 50;
        private int _blockCount = 0;
        private readonly List<string> _debugLog = new List<string>(DebugLogMaxLines);

        public MainPresenter(IMainView view, MouseEventBlocker mouseEventBlocker, IConfiguration configuration)
        {
            View = view;
            View.Presenter = this;
            MouseEventBlocker = mouseEventBlocker;
            Configuration = configuration;
            Initialize();
        }

        private void Initialize()
        {
            View.Threshold = Convert.ToInt32(Configuration[nameof(View.Threshold)]);
            View.LeftMouseButton = Convert.ToBoolean(Configuration[nameof(View.LeftMouseButton)]);
            View.RightMouseButton = Convert.ToBoolean(Configuration[nameof(View.RightMouseButton)]);

            MouseEventBlocker.EventHandled += MouseEventBlocker_EventHandled;
            UpdateBlockStatusLabel();
            View.IsDebugging = false;
        }

        private void MouseEventBlocker_EventHandled(object sender, MouseEventArgs e)
        {
            if (e.IsBlocked)
            {
                _blockCount++;
                UpdateBlockStatusLabel();
            }

            _debugLog.Add($"{e.Timestamp} (d:{e.TimeDiff}ms) X:{e.X} Y:{e.Y} {e.MouseEvent} {(e.IsBlocked ? "BLOCKED" : "OK")}");
            UpdateDebugLog();
        }

        private void UpdateDebugLog()
        {
            if (_debugLog.Count > DebugLogMaxLines)
            {
                var excess = _debugLog.Count - DebugLogMaxLines;
                _debugLog.RemoveRange(0, excess);
            }

            View.DebugLog = _debugLog.ToArray();
        }

        public IMainView View { get; }
        public MouseEventBlocker MouseEventBlocker { get; }
        public IConfiguration Configuration { get; }

        public void UpdateThreshold()
        {
            MouseEventBlocker.Threshold = (uint)View.Threshold;

            View.ThresholdLabel = $"Threshold ({View.Threshold}ms)";

            Configuration[nameof(View.Threshold)] = View.Threshold.ToString();
        }

        public void UpdateLeftMouseButton()
        {
            if (View.LeftMouseButton)
            {
                MouseEventBlocker.Register(Win32.MouseInputNotification.WM_LBUTTONUP);
                MouseEventBlocker.Register(Win32.MouseInputNotification.WM_LBUTTONDOWN);
            }
            else
            {
                MouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_LBUTTONUP);
                MouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_LBUTTONDOWN);
            }

            Configuration[nameof(View.LeftMouseButton)] = View.LeftMouseButton.ToString();
        }

        public void UpdateRightMouseButton()
        {
            if (View.RightMouseButton)
            {
                MouseEventBlocker.Register(Win32.MouseInputNotification.WM_RBUTTONUP);
                MouseEventBlocker.Register(Win32.MouseInputNotification.WM_RBUTTONDOWN);
            }
            else
            {
                MouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_RBUTTONUP);
                MouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_RBUTTONDOWN);
            }

            Configuration[nameof(View.RightMouseButton)] = View.RightMouseButton.ToString();
        }

        public void UpdateBlockStatusLabel()
        {
            View.BlockStatusLabel = $"Blocked events: {_blockCount}";
        }
    }
}
