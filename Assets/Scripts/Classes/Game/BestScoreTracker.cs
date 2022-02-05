using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.Game
{
    public class BestScoreTracker : IBestValueTracker<int>
    {
        public int Value => _scoreSerializer.Deserialize();
        public event Action<int> ValueIncreased;

        private readonly ISerializer<int> _scoreSerializer;


        public BestScoreTracker()
        {
            _scoreSerializer = new ScoreSerializer();
        }
        
        
        public void TryToSetNewBest(int value)
        {
            if (value > Value)
            {
                _scoreSerializer.Serialize(value);
                ValueIncreased?.Invoke(value);
            }
        }
    }
}