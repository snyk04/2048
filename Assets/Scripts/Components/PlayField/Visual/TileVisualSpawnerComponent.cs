using TwentyFortyEight.PlayField.Logic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualSpawnerComponent : MonoBehaviour
    {
        [SerializeField] private TileSpawnerComponent _tileSpawner;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private BoardVisualComponent _boardVisual;
        
        
        public TileVisualSpawner TileVisualSpawner { get; private set; }


        private void Awake()
        {
            TileVisualSpawner = new TileVisualSpawner(_tileSpawner.TileSpawner, _tilePrefab, _boardVisual.BoardVisual);
        }
    }
}