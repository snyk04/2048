using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualMoverComponent : MonoBehaviour
    {
        [SerializeField] private TileMoverComponent _tileMover;
        [SerializeField] private BoardVisualComponent _board;
        
        
        public TileVisualMover TileVisualMover { get; private set; }


        private void Awake()
        {
            TileVisualMover = new TileVisualMover(_tileMover.TileMover, _board.BoardVisual);
        }
    }
}