using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight.GameHandling
{
    public interface IGameHandler
    {
        event Action OnGameStart;
        
        IIndexable<IContainer<IContainer<int>>> Board { get; }
        IObjectMerger<int> TileMerger { get; }
        IObjectMover TileMover { get; }
        IObjectSpawner<IContainer<int>> TileSpawner { get; }
        IAddableValueTracker<int> CurrentScoreTracker { get; }
        IBestValueTracker<int> BestScoreTracker { get; }


        void StartGame(int amountOfRows, int amountOfColumns);
        void Move(Direction direction);
    }
}