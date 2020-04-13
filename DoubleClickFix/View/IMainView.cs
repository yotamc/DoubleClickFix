using DoubleClickFix.Presenter;

namespace DoubleClickFix.View
{
    public interface IMainView
    {
        public bool LeftMouseButton { get; set; }
        public uint Threshold { get; set; }

        public MainPresenter Presenter { set; }
    }
}
