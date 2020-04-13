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
        }

        public IMainView View { get; }
        public MouseEventBlocker MouseEventBlocker { get; }

        public void UpdateThreshold()
        {
            MouseEventBlocker.Threshold = View.Threshold;
        }

        internal void UpdateLeftButton()
        {
            if (View.LeftMouseButton)
                MouseEventBlocker.Register(MouseEvent.LeftMouseButton);
            else
                MouseEventBlocker.Unegister(MouseEvent.LeftMouseButton);
        }
    }
}
