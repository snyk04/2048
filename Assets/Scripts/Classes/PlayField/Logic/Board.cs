using TwentyFortyEight.Common;

namespace TwentyFortyEight.PlayField.Logic
{
    public class Board : IIndexable<IContainer<IContainer<int>>>
    {
        private IContainer<IContainer<int>>[,] _cells;

        
        public Board(int amountOfRows, int amountOfColumns)
        {
            Initialize(amountOfRows, amountOfColumns);
        }
        
        public IContainer<IContainer<int>> this[int i, int j]
        {
            get => _cells[i, j];
            set => _cells[i, j] = value;
        }
        public IContainer<IContainer<int>> this[(int, int) coordinates]
        {
            get => _cells[coordinates.Item1, coordinates.Item2];
            set => _cells[coordinates.Item1, coordinates.Item2] = value;
        }


        public int GetLength(int dimension)
        {
            return _cells.GetLength(dimension);
        }
        
        private void Initialize(int amountOfRows, int amountOfColumns)
        {
            _cells = new IContainer<IContainer<int>>[amountOfRows, amountOfColumns];

            for (int i = 0; i < amountOfRows; i++)
            {
                for (int j = 0; j < amountOfColumns; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }
    }
}