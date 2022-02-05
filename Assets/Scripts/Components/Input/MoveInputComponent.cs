using TwentyFortyEight.GameHandling;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TwentyFortyEight.Input
{
    public class MoveInputComponent : MonoBehaviour
    {
        [SerializeField] private GameHandlerComponent _gameHandler;
        
        
        public MoveInput MoveInput { get; private set; }


        private void Awake()
        {
            InputAction moveAction = new Controls().Player.Move;
            MoveInput = new MoveInput(moveAction, _gameHandler.GameHandler);
        }
        private void OnEnable()
        {
            MoveInput.OnEnable();
        }
        private void OnDisable()
        {
            MoveInput.OnDisable();
        }
        private void OnDestroy()
        {
            MoveInput.OnDestroy();
        }
    }
}