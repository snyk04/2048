using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.Game
{
    public class CurrentScoreTracker : IAddableValueTracker<int>
    {
        public event Action<int> ValueIncreased;

        private int _value;
        
        
        public void Add(int value)
        {
            _value += value;
            ValueIncreased?.Invoke(_value);
        }
    }
}