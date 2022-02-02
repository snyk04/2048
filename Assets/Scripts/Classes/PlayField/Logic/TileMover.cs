using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMover : IObjectMover
    {
        public event Action<(int, int), (int, int)> OnMove;
        public event Action<(int, int), (int, int), int> OnMerge;
        public event Action AnyTileMoved; 


        public void Move(Direction direction, IIndexable<IContainer<IContainer<int>>> objects)
        {
            switch (direction)
            {
                case Direction.Up:
                    MoveUp(objects);
                    break;
                case Direction.Right:
                    MoveRight(objects);
                    break;
                case Direction.Down:
                    MoveDown(objects);
                    break;
                case Direction.Left:
                    MoveLeft(objects);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        private void MoveLeft(IIndexable<IContainer<IContainer<int>>> objects)
        {
            bool movePerformed = false;
            
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = 0;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = 0; j < objects.GetLength(1); j++)
                {
                    if (objects[i, j].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (i, j)
                        && AreTilesMergeable(
                            objects[lastTileCoordinates.Item1, lastTileCoordinates.Item2].Value,
                            objects[i, j].Value))
                    {
                        MergeTiles(lastTileCoordinates, (i, j), objects);
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (i, j), (i, firstFreePosition));
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
        private void MoveRight(IIndexable<IContainer<IContainer<int>>> objects)
        {
            bool movePerformed = false;

            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = objects.GetLength(1) - 1;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = objects.GetLength(1) - 1; j >= 0; j--)
                {
                    if (objects[i, j].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (i, j)
                        && AreTilesMergeable(
                            objects[lastTileCoordinates.Item1, lastTileCoordinates.Item2].Value,
                            objects[i, j].Value))
                    {
                        MergeTiles(lastTileCoordinates, (i, j), objects);
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (i, j), (i, firstFreePosition));
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
        private void MoveDown(IIndexable<IContainer<IContainer<int>>> objects)
        {
            bool movePerformed = false;

            for (int i = 0; i < objects.GetLength(1); i++)
            {
                int firstFreePosition = objects.GetLength(0) - 1;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = objects.GetLength(0) - 1; j >= 0; j--)
                {
                    if (objects[j, i].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (j, i)
                        && AreTilesMergeable(
                            objects[lastTileCoordinates.Item1, lastTileCoordinates.Item2].Value,
                            objects[j, i].Value))
                    {
                        MergeTiles(lastTileCoordinates, (j, i), objects);
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (j, i), (firstFreePosition, i));
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
        private void MoveUp(IIndexable<IContainer<IContainer<int>>> objects)
        {
            bool movePerformed = false;
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = 0;
                (int, int) lastTileCoordinates = (-1, -1);
                for (int j = 0; j < objects.GetLength(1); j++)
                {
                    if (objects[j, i].Value == null)
                    {
                        continue;
                    }

                    if (lastTileCoordinates != (-1, -1) 
                        && lastTileCoordinates != (j, i)
                        && AreTilesMergeable(
                            objects[lastTileCoordinates.Item1, lastTileCoordinates.Item2].Value,
                            objects[j, i].Value))
                    {
                        MergeTiles(lastTileCoordinates, (j, i), objects);
                        movePerformed = true;
                        continue;
                    }
                    
                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (j, i), (firstFreePosition, i));
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
            IContainer<IContainer<int>> cellToMoveFrom = board[moveFrom.Item1, moveFrom.Item2];
            IContainer<IContainer<int>> cellToMoveTo = board[moveTo.Item1, moveTo.Item2];
            IContainer<int> tileToMove = cellToMoveFrom.Value;
            cellToMoveTo.Value = tileToMove;
            cellToMoveFrom.Value = null;

            OnMove?.Invoke(moveFrom, moveTo);
        }
        
        // TODO : Move methods to single responsibility class/interface
        private bool AreTilesMergeable(IContainer<int> tileToMergeInto, IContainer<int> mergedTile)
        {
            // TODO : Move it to IContainer<T> interface as bool AreEqual()
            return tileToMergeInto.Value == mergedTile.Value;
        }
        private void MergeTiles((int, int) tileToMergeIntoCoordinates, (int, int) mergedTileCoordinates,
            IIndexable<IContainer<IContainer<int>>> board)
        {
            IContainer<int> tileToMergeInto = board[tileToMergeIntoCoordinates.Item1, tileToMergeIntoCoordinates.Item2].Value;
            tileToMergeInto.Value *= 2;
            board[mergedTileCoordinates.Item1, mergedTileCoordinates.Item2].Value = null;
            
            OnMerge?.Invoke(tileToMergeIntoCoordinates, mergedTileCoordinates, tileToMergeInto.Value);
        }
    }
}