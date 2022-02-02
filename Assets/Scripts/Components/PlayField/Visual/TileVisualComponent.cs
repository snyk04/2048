using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualComponent : MonoBehaviour
    {
        public TileVisual TileVisual { get; private set; }


        private void Awake()
        {
            TileVisual = new TileVisual(transform);
        }
    }
}