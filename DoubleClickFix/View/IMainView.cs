using DoubleClickFix.Presenter;

namespace DoubleClickFix.View
{
    public interface IMainView
    {
        bool LeftMouseButton { get; set; }
        bool RightMouseButton { get; set; }
        uint Threshold { get; set; }

        MainPresenter Presenter { set; }
    }
}
