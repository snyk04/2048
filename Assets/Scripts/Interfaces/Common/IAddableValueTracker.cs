namespace TwentyFortyEight.Common
{
    public interface IAddableValueTracker<T> : IValueTracker<T>
    {
        void Add(T value);
    }
}