using UnityEngine;
using UnityEngine.UI;

namespace TwentyFortyEight.UI
{
    public class UIScoreTracker
    {
        private readonly IGameHandler _gameHandler;
        private readonly Text _currentScoreText;
        private readonly Text _bestScoreText;
        private readonly GameObject _scoreInterface;


        public UIScoreTracker(IGameHandler gameHandler, Text currentScoreText, Text bestScoreText,
            GameObject scoreInterface)
        {
            _gameHandler = gameHandler;
            _currentScoreText = currentScoreText;
            _bestScoreText = bestScoreText;
            _scoreInterface = scoreInterface;

            gameHandler.OnGameStart += Initialize;
        }

        
        private void Initialize()
        {
            _gameHandler.ScoreTracker.ValueIncreased += UpdateScore;
            _scoreInterface.SetActive(true);
        }
        private void UpdateScore()
        {
            _currentScoreText.text = _gameHandler.ScoreTracker.Value.ToString();
        }
    }
}