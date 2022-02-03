using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class BoardVisual : IIndexable<CellVisual>
    {
        private readonly GameObject _boardPrefab;
        private readonly GameObject _cellPrefab;
        private readonly float _offsetBetweenCells;

        private readonly float _cellWidth;
        private readonly float _cellHeight;

        private float _boardWidth;
        private float _boardHeight;

        private Vector3 _boardCenter;

        private CellVisual[,] _cellVisuals;

        private GameObject _board;


        public BoardVisual(IIndexable<IContainer<IContainer<int>>> board, 
            GameObject boardPrefab, GameObject cellPrefab, float offsetBetweenCells)
        {
            _boardPrefab = boardPrefab;
            _cellPrefab = cellPrefab;
            _offsetBetweenCells = offsetBetweenCells;

            Vector2 cellSize = _cellPrefab.GetComponent<SpriteRenderer>().size;
            _cellWidth = cellSize.x;
            _cellHeight = cellSize.y;

            int amountOfRows = board.GetLength(0);
            int amountOfColumns = board.GetLength(1);
            CreateBoard(amountOfRows, amountOfColumns);
            CreateCells(amountOfRows, amountOfColumns);
        }

        public CellVisual this[int i, int j]
        {
            get => _cellVisuals[i, j];
            set => _cellVisuals[i, j] = value;
        }

        
        public int GetLength(int dimension)
        {
            return _cellVisuals.GetLength(dimension);
        }

        private void CreateBoard(int amountOfRows, int amountOfColumns)
        {
            _board = Object.Instantiate(_boardPrefab, Vector3.zero, Quaternion.identity);

            _boardWidth = _cellWidth * amountOfColumns + _offsetBetweenCells * (amountOfColumns + 1);
            _boardHeight = _cellHeight * amountOfRows + _offsetBetweenCells * (amountOfRows + 1);

            var boardTransform = _board.GetComponent<Transform>();
            _board.GetComponent<SpriteRenderer>().size = new Vector2(_boardWidth, _boardHeight);
            boardTransform.localPosition = Vector3.zero;

            _boardCenter = boardTransform.position;
        }
        private void CreateCells(int amountOfRows, int amountOfColumns)
        {
            _cellVisuals = new CellVisual[amountOfRows, amountOfColumns];
            Vector3 topLeftCellPosition = _boardCenter
                                          - new Vector3(_boardWidth / 2 - _offsetBetweenCells - _cellWidth / 2, 0, 0)
                                          + new Vector3(0, _boardHeight / 2 - _offsetBetweenCells - _cellHeight / 2, 0);
            
            for (int i = 0; i < amountOfRows; i++)
            {
                for (int j = 0; j < amountOfColumns; j++)
                {
                    Vector3 cellPosition = 
                        topLeftCellPosition 
                        + new Vector3(j * (_cellWidth + _offsetBetweenCells), -i * (_cellHeight + _offsetBetweenCells), 0);
                    
                    GameObject cell = Object.Instantiate(
                        _cellPrefab,
                        cellPosition,
                        Quaternion.identity,
                        _board.transform
                    );

                    _cellVisuals[i, j] = cell.GetComponent<CellVisualComponent>().CellVisual;
                }
            }
        }
    }
}