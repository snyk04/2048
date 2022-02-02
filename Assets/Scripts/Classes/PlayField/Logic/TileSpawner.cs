using System;
using System.Collections.Generic;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    // TODO : Create interface
    public class TileSpawner
    {
        private const float OpportunityOf4ToBeSpawned = 0.2f;
        
        public event Action<(int, int), int> OnSpawn;
        

        public void SpawnTileAtRandomPosition(IIndexable<IContainer<IContainer<int>>> board, int tilesToSpawn = 1)
        {
            var freeCells = new List<(int, int)>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Value == null)
                    {
                        freeCells.Add((i, j));
                    }
                }
            }

            var random = new Random();
            for (int i = 0; i < tilesToSpawn; i++)
            {
                (int, int) coordinates = freeCells[random.Next(freeCells.Count)];
                int tileValue = random.NextDouble() > OpportunityOf4ToBeSpawned ? 2 : 4;
                SpawnTile(coordinates, tileValue, board);
            }
        }
        private void SpawnTile((int, int) coordinates, int value, IIndexable<IContainer<IContainer<int>>> board)
        {
            board[coordinates.Item1, coordinates.Item2].Value = new Tile(value);
            OnSpawn?.Invoke(coordinates, value);
        }
    }
}