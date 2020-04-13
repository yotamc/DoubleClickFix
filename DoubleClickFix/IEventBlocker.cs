namespace DoubleClickFix
{
    public interface IEventBlocker<T> //TODO IDisposable
    {
        uint Threshold { get; set; }
        void Register(T value);
        void Unegister(T value);
        void Start();
        void Stop();
    }
}