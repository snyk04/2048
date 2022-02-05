using TwentyFortyEight.Common;
using TwentyFortyEight.GameHandling;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TwentyFortyEight.Input
{
    public class MoveInput
    {
        private readonly InputAction _inputAction;
        private readonly IGameHandler _gameHandler;
        
        
        public MoveInput(InputAction inputAction, IGameHandler gameHandler)
        {
            _inputAction = inputAction;
            _gameHandler = gameHandler;

            _inputAction.performed += Move;
        }
        
        
        public void OnEnable()
        {
            _inputAction.Enable();
        }
        public void OnDisable()
        {
            _inputAction.Disable();
        }
        public void OnDestroy()
        {
            _inputAction.performed -= Move;
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            var directionVector = context.ReadValue<Vector2>();
            _gameHandler.Move(directionVector.GetDirection());
        }
    }
}