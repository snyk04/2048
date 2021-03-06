using UnityEngine;

namespace TwentyFortyEight.GameHandling
{
    // TODO : Make board size configurable in UI
    public class GameHandlerComponent : MonoBehaviour
    {
        public IGameHandler GameHandler { get; private set; }


        private void Awake()
        {
            GameHandler = new GameHandler();
        }
        private void Start()
        {
            StartGame();
        }
        
        public void StartGame()
        {
            GameHandler.StartGame(4, 4);
        }
    }
}