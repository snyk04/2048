using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight
{
    public class GameManager
    {
        public GameManager(IIndexable<IContainer<IContainer<int>>> board, TileSpawner tileSpawner, IObjectMover tileMover)
        {
            tileSpawner.SpawnTileAtRandomPosition(board, 2);
            tileMover.AnyTileMoved += () => tileSpawner.SpawnTileAtRandomPosition(board);
        }
    }
}