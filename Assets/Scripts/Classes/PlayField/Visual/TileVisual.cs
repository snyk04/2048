using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisual
    {
        public Transform Transform { get; }

        
        public TileVisual(Transform transform)
        {
            Transform = transform;
        }
    }
}