using UnityEngine;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileMoverComponent : MonoBehaviour
    {
        [SerializeField] private BoardComponent _board;
        
        
        public IObjectMover TileMover { get; private set; }


        private void Awake()
        {
            TileMover = new TileMover();
        }

        public void Move(int direction)
        {
            TileMover.Move((Direction) direction, _board.Board);
        }
    }
}