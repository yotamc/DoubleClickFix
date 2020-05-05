using DoubleClickFix.View;
using Microsoft.Extensions.Configuration;
using System;

namespace DoubleClickFix.Presenter
{
    public class MainPresenter
    {
        private int _blockCount = 0;

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
        }

        private void MouseEventBlocker_EventHandled(object sender, MouseEventArgs e)
        {
            if (e.IsBlocked)
            {
                _blockCount++;
                UpdateBlockStatusLabel();
            }

            //TODO add to debug textbox
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
