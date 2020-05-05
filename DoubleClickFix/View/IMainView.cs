using DoubleClickFix.Presenter;

namespace DoubleClickFix.View
{
    public interface IMainView
    {
        bool LeftMouseButton { get; set; }
        bool RightMouseButton { get; set; }
        int Threshold { get; set; }
        string ThresholdLabel { get; set; }

        MainPresenter Presenter { set; }
    }
}
