using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
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


        public void StartGame(int amountOfRows, int amountOfColumns)
        {
            Board = new Board(amountOfRows, amountOfColumns);
            TileMerger = new TileMerger(Board, VictoryNumber);
            TileMover = new TileMover(Board, TileMerger);
            TileSpawner = new TileSpawner(Board);

            OnGameStart?.Invoke();

            TileSpawner.SpawnAtRandomPosition(AmountOfTilesToSpawnAtStart);
            TileMover.AnyMovePerformed += () => TileSpawner.SpawnAtRandomPosition();
        }
        public void Move(Direction direction)
        {
            TileMover.Move(direction);
        }
    }
}