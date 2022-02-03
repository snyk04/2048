using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight
{
    public interface IGameHandler
    {
        event Action OnGameStart;
        
        
        void StartGame(int amountOfRows, int amountOfColumns);
        void Move(Direction direction);
        
        IIndexable<IContainer<IContainer<int>>> Board { get; }
        IObjectMerger<int> TileMerger { get; }
        IObjectMover TileMover { get; }
        IObjectSpawner<IContainer<int>> TileSpawner { get; }
    }
}