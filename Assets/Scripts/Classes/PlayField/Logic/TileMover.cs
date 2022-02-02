using System;
using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMover : IObjectMover
    {
        public event Action<(int, int), (int, int)> OnMove;


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
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = 0;
                for (int j = 0; j < objects.GetLength(1); j++)
                {
                    if (objects[i, j].Value == null)
                    {
                        continue;
                    }

                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (i, j), (i, firstFreePosition));
                    }

                    firstFreePosition += 1;
                }
            }
        }
        private void MoveRight(IIndexable<IContainer<IContainer<int>>> objects)
        {
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = objects.GetLength(1) - 1;
                for (int j = objects.GetLength(1) - 1; j >= 0; j--)
                {
                    if (objects[i, j].Value == null)
                    {
                        continue;
                    }

                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (i, j), (i, firstFreePosition));
                    }

                    firstFreePosition -= 1;
                }
            }
        }
        private void MoveDown(IIndexable<IContainer<IContainer<int>>> objects)
        {
            for (int i = 0; i < objects.GetLength(1); i++)
            {
                int firstFreePosition = objects.GetLength(0) - 1;
                for (int j = objects.GetLength(0) - 1; j >= 0; j--)
                {
                    if (objects[j, i].Value == null)
                    {
                        continue;
                    }

                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (j, i), (firstFreePosition, i));
                    }

                    firstFreePosition -= 1;
                }
            }
        }
        private void MoveUp(IIndexable<IContainer<IContainer<int>>> objects)
        {
            for (int i = 0; i < objects.GetLength(0); i++)
            {
                int firstFreePosition = 0;
                for (int j = 0; j < objects.GetLength(1); j++)
                {
                    if (objects[j, i].Value == null)
                    {
                        continue;
                    }

                    if (firstFreePosition != j)
                    {
                        MoveTile(objects, (j, i), (firstFreePosition, i));
                    }

                    firstFreePosition += 1;
                }
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
    }
}