using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMover : IObjectMover
    {
        public event Action<(int, int), (int, int)> OnMove;
        public event Action AnyTileMoved;

        private readonly IIndexable<IContainer<IContainer<int>>> _board;
        private readonly IObjectMerger<int> _tileMerger;


        public TileMover(IIndexable<IContainer<IContainer<int>>> board, IObjectMerger<int> tileMerger)
        {
            _board = board;
            _tileMerger = tileMerger;
        }
        
        
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    MoveUp(_board);
                    break;
                case Direction.Right:
                    MoveRight(_board);
                    break;
                case Direction.Down:
                    MoveDown(_board);
                    break;
                case Direction.Left:
                    MoveLeft(_board);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        
        // TODO : Refactor this shit
        private void MoveLeft(IIndexable<IContainer<IContainer<int>>> board)
        {
            bool movePerformed = false;
            
            for (int i = 0; i < board.GetLength(0); i++)
            {
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
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[i, j].Value))
                    {
                        _tileMerger.Merge(lastTileCoordinates, (i, j));
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (i, j), (i, firstFreePosition));
                        movePerformed = true;
                        lastTileCoordinates = (i, firstFreePosition);
                        firstFreePosition += 1;
                        continue;
                    }

                    lastTileCoordinates = (i, j);
                    firstFreePosition += 1;
                }
            }

            if (movePerformed)
            {
                AnyTileMoved?.Invoke();
            }
        }
        private void MoveRight(IIndexable<IContainer<IContainer<int>>> board)
        {
            bool movePerformed = false;

            for (int i = 0; i < board.GetLength(0); i++)
            {
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
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[i, j].Value))
                    {
                        _tileMerger.Merge(lastTileCoordinates, (i, j));
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (i, j), (i, firstFreePosition));
                        movePerformed = true;
                        lastTileCoordinates = (i, firstFreePosition);
                        firstFreePosition -= 1;
                        continue;
                    }

                    lastTileCoordinates = (i, j);
                    firstFreePosition -= 1;
                }
            }
            
            if (movePerformed)
            {
                AnyTileMoved?.Invoke();
            }
        }
        private void MoveDown(IIndexable<IContainer<IContainer<int>>> board)
        {
            bool movePerformed = false;

            for (int i = 0; i < board.GetLength(1); i++)
            {
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
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[j, i].Value))
                    {
                        _tileMerger.Merge(lastTileCoordinates, (j, i));
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (j, i), (firstFreePosition, i));
                        movePerformed = true;
                        lastTileCoordinates = (firstFreePosition, i);
                        firstFreePosition -= 1;
                        continue;
                    }

                    lastTileCoordinates = (j, i);
                    firstFreePosition -= 1;
                }
            }
            
            if (movePerformed)
            {
                AnyTileMoved?.Invoke();
            }
        }
        private void MoveUp(IIndexable<IContainer<IContainer<int>>> board)
        {
            bool movePerformed = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
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
                        && AreTilesMergeable(board[lastTileCoordinates].Value, board[j, i].Value))
                    {
                        _tileMerger.Merge(lastTileCoordinates, (j, i));
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(board, (j, i), (firstFreePosition, i));
                        movePerformed = true;
                        lastTileCoordinates = (firstFreePosition, i);
                        firstFreePosition += 1;
                        continue;
                    }
                    
                    lastTileCoordinates = (j, i);
                    firstFreePosition += 1;
                }
            }
            
            if (movePerformed)
            {
                AnyTileMoved?.Invoke();
            }
        }
        
        private void MoveTile(IIndexable<IContainer<IContainer<int>>> board, (int, int) moveFrom, (int, int) moveTo)
        {
            IContainer<IContainer<int>> cellToMoveFrom = board[moveFrom];
            IContainer<IContainer<int>> cellToMoveTo = board[moveTo];
            IContainer<int> tileToMove = cellToMoveFrom.Value;
            cellToMoveTo.Value = tileToMove;
            cellToMoveFrom.Value = null;

            OnMove?.Invoke(moveFrom, moveTo);
        }
        
        private bool AreTilesMergeable(IContainer<int> tileToMergeInto, IContainer<int> mergedTile)
        {
            return tileToMergeInto.Value == mergedTile.Value;
        }
    }
}