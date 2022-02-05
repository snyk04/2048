using System;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight.Common
{
    public interface IObjectMover
    {
        event Action<(int, int), (int, int)> OnMove;
        event Action AnyMovePerformed;
        event Action OnNoMovesLeft;
        bool IsInCheckMode { get; set; }
        
        
        void Move(Direction direction);
    }
}