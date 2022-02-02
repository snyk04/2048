using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class CellVisualComponent : MonoBehaviour
    {
        public CellVisual CellVisual { get; private set; }


        private void Awake()
        {
            CellVisual = new CellVisual(transform);
        }
    }
}