using UnityEngine;

namespace TwentyFortyEight.GameHandling
{
    public class GameStopHandlerComponent : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameHandlerComponent _gameHandler;
        
        [Header("Interfaces")]
        [SerializeField] private GameObject _victoryInterface;
        [SerializeField] private GameObject _gameOverInterface;

        
        public GameStopHandler GameStopHandler { get; private set; }

        
        private void Awake()
        {
            GameStopHandler = new GameStopHandler(_gameHandler.GameHandler, _victoryInterface, _gameOverInterface);
        }
    }
}