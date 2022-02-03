﻿using UnityEngine;

namespace TwentyFortyEight.PlayField.Logic
{
    public class GameHandlerComponent : MonoBehaviour
    {
        public IGameHandler GameHandler { get; private set; }


        private void Awake()
        {
            GameHandler = new GameHandler();
        }
        
        // TODO : Make board size configurable in UI
        public void StartGame()
        {
            GameHandler.StartGame(4, 4);
        }
        public void Move(int direction)
        {
            GameHandler.Move((Direction) direction);
        }
    }
}