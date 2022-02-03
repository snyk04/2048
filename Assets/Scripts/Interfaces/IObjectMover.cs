using System;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight
{
    public interface IObjectMover
    {
        event Action<(int, int), (int, int)> OnMove;
        event Action AnyTileMoved;
        
        
        void Move(Direction direction);
    }
}