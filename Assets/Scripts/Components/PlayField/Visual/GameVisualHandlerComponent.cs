using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class GameVisualHandlerComponent : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameHandlerComponent _gameHandler;
        
        [Header("Visuals")]
        [SerializeField] private GameObject _boardPrefab;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private float _offsetBetweenCells;


        public GameVisualHandler GameVisualHandler { get; private set; }
        
        
        private void Awake()
        {
            GameVisualHandler = new GameVisualHandler(_gameHandler.GameHandler,
                _boardPrefab, _cellPrefab, _tilePrefab, _offsetBetweenCells);
        }
    }
}