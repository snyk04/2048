using UnityEngine;

namespace TwentyFortyEight.GameHandling
{
    public class GameStopHandler
    {
        private readonly IGameHandler _gameHandler;
        
        private readonly GameObject _victoryInterface;
        private readonly GameObject _gameOverInterface;
        
        
        public GameStopHandler(IGameHandler gameHandler, GameObject victoryInterface, GameObject gameOverInterface)
        {
            _gameHandler = gameHandler;
            _victoryInterface = victoryInterface;
            _gameOverInterface = gameOverInterface;

            gameHandler.OnGameStart += Prepare;
        }


        private void Prepare()
        {
            _gameHandler.TileMover.OnNoMovesLeft += HandleGameOver;
            _gameHandler.TileMerger.OnVictoryNumberReach += HandleVictory;
        }

        private void HandleVictory()
        {
            _victoryInterface.SetActive(true);
        }
        private void HandleGameOver()
        {
            _gameOverInterface.SetActive(true);
        }
    }
}