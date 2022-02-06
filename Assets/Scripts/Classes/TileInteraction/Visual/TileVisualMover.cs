using DG.Tweening;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Visual;

namespace TwentyFortyEight.TileInteraction.Visual
{
    public class TileVisualMover
    {
        public const float MoveDuration = 0.1f;
        
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

            tileToMove.Transform.parent = cellToMoveTo.Transform;
            tileToMove.Transform.DOMove(cellToMoveTo.Transform.position, MoveDuration);
        }
    }
}