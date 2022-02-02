using TMPro;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisualComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        
        public TileVisual TileVisual { get; private set; }


        private void Awake()
        {
            TileVisual = new TileVisual(transform, _text, _spriteRenderer);
        }
    }
}