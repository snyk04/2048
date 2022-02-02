using UnityEngine;

namespace TwentyFortyEight.PlayField.Logic
{
    public class TileSpawnerComponent : MonoBehaviour
    {
        public TileSpawner TileSpawner { get; private set; }


        private void Awake()
        {
            TileSpawner = new TileSpawner();
        }
    }
}