using TwentyFortyEight.GameHandling;
using UnityEngine.UI;

namespace TwentyFortyEight.UI
{
    public class UIScoreTracker
    {
        private readonly IGameHandler _gameHandler;
        
        private readonly Text _currentScoreText;
        private readonly Text _bestScoreText;


        public UIScoreTracker(IGameHandler gameHandler, Text currentScoreText, Text bestScoreText)
        {
            _gameHandler = gameHandler;
            _currentScoreText = currentScoreText;
            _bestScoreText = bestScoreText;

            gameHandler.OnGameStart += Initialize;
        }

        
        private void Initialize()
        {
            _gameHandler.CurrentScoreTracker.ValueIncreased += UpdateCurrentScore;
            _gameHandler.BestScoreTracker.ValueIncreased += UpdateBestScore;
            
            _currentScoreText.text = 0.ToString();
            _bestScoreText.text = _gameHandler.BestScoreTracker.Value.ToString();
        }
        
        private void UpdateCurrentScore(int value)
        {
            _currentScoreText.text = value.ToString();
        }
        private void UpdateBestScore(int value)
        {
            _bestScoreText.text = value.ToString();
        }
    }
}