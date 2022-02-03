using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualMerger
    {
        private readonly IIndexable<CellVisual> _boardVisual;


        public TileVisualMerger(IIndexable<CellVisual> boardVisual)
        {
            _boardVisual = boardVisual;
        }
        
        
        public void Merge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates, 
            int valueAfterMerge)
        {
            _boardVisual[tileToMergeIntoCoordinates.Item1, tileToMergeIntoCoordinates.Item2].Value.UpdateValue(valueAfterMerge);
            Object.Destroy(_boardVisual[mergedTileCoordinates.Item1, mergedTileCoordinates.Item2].Value.Transform.gameObject);
        }
    }
}