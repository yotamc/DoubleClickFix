using System.Collections.Generic;

namespace DoubleClickFix
{
    public interface IEventBlocker<T> //TODO IDisposable
    {
        uint Threshold { get; set; }
        void Register(T value);
        void Unregister(T value);
        IEnumerable<T> Events { get; }
        void Start();
        void Stop();
    }
}