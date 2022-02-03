using System;
using System.Collections.Generic;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileSpawner : IObjectSpawner<IContainer<int>>
    {
        private const float OpportunityOf4ToBeSpawned = 0.2f;
        
        public event Action<(int, int), IContainer<int>> OnSpawn;

        private readonly IIndexable<IContainer<IContainer<int>>> _board;


        public TileSpawner(IIndexable<IContainer<IContainer<int>>> board)
        {
            _board = board;
        }
        

        public void SpawnAtRandomPosition(int tilesToSpawn = 1)
        {
            var freeCells = new List<(int, int)>();

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j].Value == null)
                    {
                        freeCells.Add((i, j));
                    }
                }
            }

            var random = new Random();
            for (int i = 0; i < tilesToSpawn; i++)
            {
                int cellIndex = random.Next(freeCells.Count);
                (int, int) coordinates = freeCells[cellIndex];
                freeCells.RemoveAt(cellIndex);
                
                int tileValue = random.NextDouble() > OpportunityOf4ToBeSpawned ? 2 : 4;
                SpawnTile(coordinates, tileValue, _board);
            }
        }
        private void SpawnTile((int, int) coordinates, int value, IIndexable<IContainer<IContainer<int>>> board)
        {
            IContainer<int> tile = new Tile(value);
            board[coordinates.Item1, coordinates.Item2].Value = tile;
            OnSpawn?.Invoke(coordinates, tile);
        }
    }
}