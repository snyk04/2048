namespace TwentyFortyEight.Common
{
    public interface IBestValueTracker<T> : IReadOnlyContainer<T>, IValueTracker<T>
    {
        void TryToSetNewBest(T value);
    }
}