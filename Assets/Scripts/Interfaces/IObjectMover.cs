using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight
{
    // TODO : Make it generic
    public interface IObjectMover
    {
        event Action<(int, int), (int, int)> OnMove;
        event Action<(int, int), (int, int), int> OnMerge;
        event Action AnyTileMoved;
        void Move(Direction direction, IIndexable<IContainer<IContainer<int>>> objects);
    }
}