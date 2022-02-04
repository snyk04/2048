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
        private Board(IContainer<IContainer<int>>[,] cells)
        {
            Initialize(cells);
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
        public IIndexable<IContainer<IContainer<int>>> Copy()
        {
            return new Board(_cells);
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
        private void Initialize(IContainer<IContainer<int>>[,] cells)
        {
            _cells = new IContainer<IContainer<int>>[cells.GetLength(0), cells.GetLength(1)];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell();
                    if (cells[i, j].Value != null)
                    {
                        _cells[i, j].Value = new Tile(cells[i, j].Value.Value);
                    }
                }
            }
        }
    }
}