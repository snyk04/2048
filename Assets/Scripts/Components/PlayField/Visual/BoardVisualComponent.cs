using TwentyFortyEight.Common;
using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class BoardVisualComponent : MonoBehaviour
    {
        [SerializeField] private BoardComponent _board;
        [SerializeField] private GameObject _boardPrefab;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private float _offsetBetweenCells;
            
        
        public IIndexable<CellVisual> BoardVisual { get; private set; }


        private void Awake()
        {
            BoardVisual = new BoardVisual(_board.Board, _boardPrefab, _cellPrefab, _offsetBetweenCells);
        }
    }
}