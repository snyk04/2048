using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualMover
    {
        private readonly IIndexable<CellVisual> _boardVisual;


        public TileVisualMover(IObjectMover tileMover, IIndexable<CellVisual> boardVisual)
        {
            _boardVisual = boardVisual;
            
            tileMover.OnMove += HandleMove;
            tileMover.OnMerge += HandleMerge;
        }


        private void HandleMove((int, int) moveFrom, (int, int) moveTo)
        {
            CellVisual cellToMoveFrom = _boardVisual[moveFrom.Item1, moveFrom.Item2];
            CellVisual cellToMoveTo = _boardVisual[moveTo.Item1, moveTo.Item2];
            TileVisual tileToMove = cellToMoveFrom.Value;
            
            cellToMoveTo.Value = tileToMove;
            cellToMoveFrom.Value = null;

            tileToMove.Transform.position = cellToMoveTo.Transform.position;
        }
        private void HandleMerge((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates, 
            int valueAfterMerge)
        {
            _boardVisual[tileToMergeIntoCoordinates.Item1, tileToMergeIntoCoordinates.Item2].Value.UpdateValue(valueAfterMerge);
            _boardVisual[mergedTileCoordinates.Item1, mergedTileCoordinates.Item2].Value.Destroy();
        }
    }
}