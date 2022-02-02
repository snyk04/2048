using TMPro;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualSpawner
    {
        private readonly GameObject _tilePrefab;
        private readonly IIndexable<CellVisual> _boardVisual;
        
        
        
        public TileVisualSpawner(TileSpawner tileSpawner, GameObject tilePrefab, IIndexable<CellVisual> boardVisual)
        {
            _tilePrefab = tilePrefab;
            _boardVisual = boardVisual;

            tileSpawner.OnSpawn += SpawnTile;
        }


        private void SpawnTile((int, int) coordinates, int value)
        {
            CellVisual cell = _boardVisual[coordinates.Item1, coordinates.Item2];
            TileVisual tile = Object.Instantiate(
                _tilePrefab,
                cell.Transform.position,
                Quaternion.identity,
                cell.Transform
                ).GetComponent<TileVisualComponent>().TileVisual;
            cell.Value = tile;
            
            tile.UpdateValue(value);
        }
    }
}