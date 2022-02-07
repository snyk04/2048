using System;
using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;

namespace TwentyFortyEight.TileInteraction.Logic
{
    public class TileMover : IObjectMover
    {
        public event Action<(int, int), (int, int)> OnMove;
        public event Action AnyMovePerformed;
        public event Action OnNoMovesLeft;
        public bool IsInCheckMode { get; set; }

        private readonly IIndexable<IContainer<IContainer<int>>> _board;
        private readonly IObjectMerger<int> _tileMerger;


        public TileMover(IIndexable<IContainer<IContainer<int>>> board, IObjectMerger<int> tileMerger)
        {
            _board = board;
            _tileMerger = tileMerger;
        }
        
        
        public void Move(Direction direction)
        {
            bool anyMovePerformed = false;
            switch (direction)
            {
                case Direction.Up:
                    MoveUp(_board, ref anyMovePerformed);
                    break;
                case Direction.Right:
                    MoveRight(_board, ref anyMovePerformed);
                    break;
                case Direction.Down:
                    MoveDown(_board, ref anyMovePerformed);
                    break;
                case Direction.Left:
                    MoveLeft(_board, ref anyMovePerformed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            if (anyMovePerformed)
            {
                AnyMovePerformed?.Invoke();
            }
            
            if (AreThereFreeCells())
            {
                return;
            }
            
            _tileMerger.IsInCheckMode = true;
            IsInCheckMode = true;
            bool anyMovePerformedToCheck = false;
            
            IIndexable<IContainer<IContainer<int>>> boardToCheck = _board.Copy();
            MoveLeft(boardToCheck, ref anyMovePerformedToCheck);
            boardToCheck = _board.Copy();
            MoveRight(boardToCheck, ref anyMovePerformedToCheck);
            boardToCheck = _board.Copy();
            MoveDown(boardToCheck, ref anyMovePerformedToCheck);
            boardToCheck = _board.Copy();
            MoveUp(boardToCheck, ref anyMovePerformedToCheck);
            
            _tileMerger.IsInCheckMode = false;
            IsInCheckMode = false;
            if (!anyMovePerformedToCheck)
            {
                OnNoMovesLeft?.Invoke();
            }
        }
        
        // TODO : Refactor this shit
        private void MoveLeft(IIndexable<IContainer<IContainer<int>>> board, ref bool anyMovePerformed)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                bool isMergeMadeOnThisMove = false;
                int firstFreePosition = 0;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (i, j)
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[i, j].Value)
                        && !isMergeMadeOnThisMove)
                    {
                        _tileMerger.Merge(board, lastTileCoordinates, (i, j));
                        anyMovePerformed = true;
                        isMergeMadeOnThisMove = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (i, j), (i, firstFreePosition));
                        anyMovePerformed = true;
                        lastTileCoordinates = (i, firstFreePosition);
                        firstFreePosition += 1;
                        continue;
                    }

                    lastTileCoordinates = (i, j);
                    firstFreePosition += 1;
                }
            }
        }
        private void MoveRight(IIndexable<IContainer<IContainer<int>>> board, ref bool anyMovePerformed)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                bool isMergeMadeOnThisMove = false;
                int firstFreePosition = board.GetLength(1) - 1;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = board.GetLength(1) - 1; j >= 0; j--)
                {
                    if (board[i, j].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (i, j)
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[i, j].Value)
                        && !isMergeMadeOnThisMove)
                    {
                        _tileMerger.Merge(board, lastTileCoordinates, (i, j));
                        anyMovePerformed = true;
                        isMergeMadeOnThisMove = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (i, j), (i, firstFreePosition));
                        anyMovePerformed = true;
                        lastTileCoordinates = (i, firstFreePosition);
                        firstFreePosition -= 1;
                        continue;
                    }

                    lastTileCoordinates = (i, j);
                    firstFreePosition -= 1;
                }
            }
        }
        private void MoveDown(IIndexable<IContainer<IContainer<int>>> board, ref bool anyMovePerformed)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                bool isMergeMadeOnThisMove = false;
                int firstFreePosition = board.GetLength(0) - 1;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = board.GetLength(0) - 1; j >= 0; j--)
                {
                    if (board[j, i].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (j, i)
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[j, i].Value)
                        && !isMergeMadeOnThisMove)
                    {
                        _tileMerger.Merge(board, lastTileCoordinates, (j, i));
                        anyMovePerformed = true;
                        isMergeMadeOnThisMove = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (j, i), (firstFreePosition, i));
                        anyMovePerformed = true;
                        lastTileCoordinates = (firstFreePosition, i);
                        firstFreePosition -= 1;
                        continue;
                    }

                    lastTileCoordinates = (j, i);
                    firstFreePosition -= 1;
                }
            }
        }
        private void MoveUp(IIndexable<IContainer<IContainer<int>>> board, ref bool anyMovePerformed)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                bool isMergeMadeOnThisMove = false;
                int firstFreePosition = 0;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[j, i].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (j, i)
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[j, i].Value)
                        && !isMergeMadeOnThisMove)
                    {
                        _tileMerger.Merge(board, lastTileCoordinates, (j, i));
                        anyMovePerformed = true;
                        isMergeMadeOnThisMove = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (j, i), (firstFreePosition, i));
                        anyMovePerformed = true;
                        lastTileCoordinates = (firstFreePosition, i);
                        firstFreePosition += 1;
                        continue;
                    }
                    
                    lastTileCoordinates = (j, i);
                    firstFreePosition += 1;
                }
            }
        }
        
        private void MoveTile(IIndexable<IContainer<IContainer<int>>> board, (int, int) moveFrom, (int, int) moveTo)
        {
            IContainer<IContainer<int>> cellToMoveFrom = board[moveFrom];
            IContainer<IContainer<int>> cellToMoveTo = board[moveTo];
            IContainer<int> tileToMove = cellToMoveFrom.Value;
            cellToMoveTo.Value = tileToMove;
            cellToMoveFrom.Value = null;

            if (!IsInCheckMode)
            {
                OnMove?.Invoke(moveFrom, moveTo);
            }
        }
        
        private bool AreTilesMergeable(IContainer<int> tileToMergeInto, IContainer<int> mergedTile)
        {
            return tileToMergeInto.Value == mergedTile.Value;
        }

        private bool AreThereFreeCells()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j].Value == null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}