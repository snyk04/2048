using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualSpawner
    {
        private readonly GameObject _tilePrefab;
        private readonly IIndexable<CellVisual> _boardVisual;
        
        
        
        public TileVisualSpawner(GameObject tilePrefab, IIndexable<CellVisual> boardVisual)
        {
            _tilePrefab = tilePrefab;
            _boardVisual = boardVisual;
        }


        public void SpawnTile((int, int) coordinates, IContainer<int> tile)
        {
            CellVisual cellVisual = _boardVisual[coordinates];
            TileVisual tileVisual = Object.Instantiate(
                _tilePrefab,
                cellVisual.Transform.position,
                Quaternion.identity,
                cellVisual.Transform
                ).GetComponent<TileVisualComponent>().TileVisual;
            cellVisual.Value = tileVisual;
            
            tileVisual.UpdateValue(tile.Value);
        }
    }
}