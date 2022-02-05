using TwentyFortyEight.Game;
using UnityEngine;
using UnityEngine.UI;

namespace TwentyFortyEight.UI
{
    public class UIScoreTrackerComponent : MonoBehaviour
    {
        [SerializeField] private GameHandlerComponent _gameHandler;
        [SerializeField] private Text _currentScoreText;
        [SerializeField] private Text _bestScoreText;
        [SerializeField] private GameObject _scoreInterface;

        
        public UIScoreTracker UIScoreTracker { get; private set; }
        
        
        private void Awake()
        {
            UIScoreTracker = new UIScoreTracker(_gameHandler.GameHandler, _currentScoreText, _bestScoreText, _scoreInterface);
        }
    }
}