using DG.Tweening;
using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualSpawner
    {
        private const float PunchScale = 0.25f;
        private const float PunchDuration = 0.1f;
        private const int PunchVibrato = 0;
        private const float PunchElasticity = 0;
        
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
            
            tileVisual.Transform.DOPunchScale(new Vector3(PunchScale, PunchScale, PunchScale),
                PunchDuration,
                PunchVibrato,
                PunchElasticity);
            cellVisual.Value = tileVisual;
            
            tileVisual.UpdateValue(tile.Value);
        }
    }
}