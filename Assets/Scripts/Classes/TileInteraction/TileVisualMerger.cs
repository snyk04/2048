using DG.Tweening;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Visual;
using UnityEngine;

namespace TwentyFortyEight.TileInteraction.Visual
{
    public class TileVisualMerger
    {
        private const float MoveDuration = 0.1f;

        private readonly IIndexable<CellVisual> _boardVisual;


        public TileVisualMerger(IIndexable<CellVisual> boardVisual)
        {
            _boardVisual = boardVisual;
        }
        
        
        public void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates, 
            int valueAfterMerge)
        {
            TileVisual tileToMergeInto = _boardVisual[tileToMergeIntoCoordinates].Value;
            TileVisual mergedTile = _boardVisual[mergedTileCoordinates].Value;
            
            tileToMergeInto.UpdateValue(valueAfterMerge);

            mergedTile.SpriteRenderer.sortingOrder -= 1;
            mergedTile.Text.sortingOrder -= 1;
            mergedTile.Transform.DOMove(tileToMergeInto.Transform.position, MoveDuration);
            Object.Destroy(mergedTile.Text, MoveDuration);
            Object.Destroy(mergedTile.SpriteRenderer, MoveDuration);
            Object.Destroy(mergedTile.Transform.gameObject, MoveDuration * 2);
        }
    }
}