using DoubleClickFix.View;

namespace DoubleClickFix.Presenter
{
    public class MainPresenter
    {
        public MainPresenter(IMainView view, MouseEventBlocker mouseEventBlocker)
        {
            View = view;
            View.Presenter = this;
            MouseEventBlocker = mouseEventBlocker;

            Initialize();
        }

        private void Initialize()
        {
            View.Threshold = MouseEventBlocker.Threshold;
        }

        public IMainView View { get; }
        public MouseEventBlocker MouseEventBlocker { get; }

        public void UpdateThreshold()
        {
            MouseEventBlocker.Threshold = View.Threshold;
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
        }
    }
}
