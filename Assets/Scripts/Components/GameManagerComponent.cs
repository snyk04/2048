using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight
{
    public class GameManagerComponent : MonoBehaviour
    {
        [SerializeField] private BoardComponent _board;
        [SerializeField] private TileSpawnerComponent _tileSpawner;
        
        
        public GameManager GameManager { get; private set; }


        private void Awake()
        {
            GameManager = new GameManager(_board.Board, _tileSpawner.TileSpawner);
        }
    }
}