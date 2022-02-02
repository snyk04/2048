using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class CellVisual : IContainer<TileVisual>
    {
        public Transform Transform { get; }
        public TileVisual Value { get; set; }


        public CellVisual(Transform transform)
        {
            Transform = transform;
        }
    }
}