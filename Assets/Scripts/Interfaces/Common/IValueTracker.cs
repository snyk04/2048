using System;

namespace TwentyFortyEight.Common
{
    public interface IValueTracker<out T>
    {
        event Action<T> ValueIncreased;
    }
}