using TwentyFortyEight.GameHandling;
using UnityEngine;
using UnityEngine.UI;

namespace TwentyFortyEight.UI
{
    public class UIScoreTrackerComponent : MonoBehaviour
    {
        [SerializeField] private GameHandlerComponent _gameHandler;
        [SerializeField] private Text _currentScoreText;
        [SerializeField] private Text _bestScoreText;

        
        public UIScoreTracker UIScoreTracker { get; private set; }
        
        
        private void Awake()
        {
            UIScoreTracker = new UIScoreTracker(_gameHandler.GameHandler, _currentScoreText, _bestScoreText);
        }
    }
}