using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class ScoreTracker : ITracker<int>
    {
        public int Value { get; private set; }

        public event Action ValueIncreased;
        
        
        public void Add(int value)
        {
            Value += value;
            ValueIncreased?.Invoke();
        }
    }

    public interface ITracker<in T> : IReadOnlyContainer<int>
    {
        event Action ValueIncreased;


        void Add(T value);
    }
}