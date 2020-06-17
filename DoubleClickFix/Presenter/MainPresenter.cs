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

using DoubleClickFix.Options;
using DoubleClickFix.View;
using System.Collections.Generic;

namespace DoubleClickFix.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly MouseEventBlocker _mouseEventBlocker;
        private readonly IWritableOptions<AppSettings> _options;

        private const int DebugLogMaxLines = 50;
        private int _blockCount = 0;
        private readonly List<string> _debugLog = new List<string>(DebugLogMaxLines);

        public MainPresenter(IMainView view, MouseEventBlocker mouseEventBlocker, IWritableOptions<AppSettings> options)
        {
            _view = view;
            _view.Presenter = this;
            _mouseEventBlocker = mouseEventBlocker;
            _options = options;
            Initialize();
        }

        private void Initialize()
        {
            _view.Threshold = _options.Value.Threshold;
            _view.LeftMouseButton = _options.Value.LeftMouseButton;
            _view.RightMouseButton = _options.Value.RightMouseButton;

            _mouseEventBlocker.EventHandled += MouseEventBlocker_EventHandled;
            UpdateBlockStatusLabel();
            _view.IsDebugging = false;
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

            _view.DebugLog = _debugLog.ToArray();
        }

        public void UpdateThreshold()
        {
            _mouseEventBlocker.Threshold = (uint)_view.Threshold;

            _view.ThresholdLabel = $"Threshold ({_view.Threshold}ms)";

            _options.Update(o => o.Threshold = _view.Threshold);
        }

        public void UpdateLeftMouseButton()
        {
            if (_view.LeftMouseButton)
            {
                _mouseEventBlocker.Register(Win32.MouseInputNotification.WM_LBUTTONUP);
                _mouseEventBlocker.Register(Win32.MouseInputNotification.WM_LBUTTONDOWN);
            }
            else
            {
                _mouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_LBUTTONUP);
                _mouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_LBUTTONDOWN);
            }

            _options.Update(o => o.LeftMouseButton = _view.LeftMouseButton);
        }

        public void UpdateRightMouseButton()
        {
            if (_view.RightMouseButton)
            {
                _mouseEventBlocker.Register(Win32.MouseInputNotification.WM_RBUTTONUP);
                _mouseEventBlocker.Register(Win32.MouseInputNotification.WM_RBUTTONDOWN);
            }
            else
            {
                _mouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_RBUTTONUP);
                _mouseEventBlocker.Unregister(Win32.MouseInputNotification.WM_RBUTTONDOWN);
            }

            _options.Update(o => o.RightMouseButton = _view.RightMouseButton);
        }

        public void UpdateBlockStatusLabel()
        {
            _view.BlockStatusLabel = $"Blocked events: {_blockCount}";
        }
    }
}
