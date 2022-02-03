using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualMover
    {
        private readonly IIndexable<CellVisual> _boardVisual;


        public TileVisualMover(IIndexable<CellVisual> boardVisual)
        {
            _boardVisual = boardVisual;
        }


        public void Move((int, int) moveFrom, (int, int) moveTo)
        {
            CellVisual cellToMoveFrom = _boardVisual[moveFrom];
            CellVisual cellToMoveTo = _boardVisual[moveTo];
            TileVisual tileToMove = cellToMoveFrom.Value;
            
            cellToMoveTo.Value = tileToMove;
            cellToMoveFrom.Value = null;

            tileToMove.Transform.position = cellToMoveTo.Transform.position;
        }
    }
}