using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.Score;
using TwentyFortyEight.TileInteraction.Logic;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight.GameHandling
{
    public class GameHandler : IGameHandler
    {
        private const int AmountOfTilesToSpawnAtStart = 2;
        private const int VictoryNumber = 2048;
        
        public event Action OnGameStart;

        public IIndexable<IContainer<IContainer<int>>> Board { get; private set; }
        public IObjectMerger<int> TileMerger { get; private set; }
        public IObjectMover TileMover { get; private set; }
        public IObjectSpawner<IContainer<int>> TileSpawner { get; private set; }
        public IAddableValueTracker<int> CurrentScoreTracker { get; private set; }
        public IBestValueTracker<int> BestScoreTracker { get; private set; }


        public void StartGame(int amountOfRows, int amountOfColumns)
        {
            Board = new Board(amountOfRows, amountOfColumns);
            TileMerger = new TileMerger(Board, VictoryNumber);
            TileMover = new TileMover(Board, TileMerger);
            TileSpawner = new TileSpawner(Board);
            CurrentScoreTracker = new CurrentScoreTracker();
            BestScoreTracker = new BestScoreTracker();

            OnGameStart?.Invoke();

            TileMerger.OnMerge += (_, __, mergedValue) => CurrentScoreTracker.Add(mergedValue);
            TileMover.AnyMovePerformed += () => TileSpawner.SpawnAtRandomPosition();
            TileSpawner.SpawnAtRandomPosition(AmountOfTilesToSpawnAtStart);
            CurrentScoreTracker.ValueIncreased += BestScoreTracker.TryToSetNewBest;
        }
        public void Move(Direction direction)
        {
            TileMover.Move(direction);
        }
    }
}