using TMPro;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisual
    {
        public Transform Transform { get; }
        
        private readonly TextMeshPro _text;
        private readonly SpriteRenderer _spriteRenderer;
        
        public TileVisual(Transform transform, TextMeshPro text, SpriteRenderer spriteRenderer)
        {
            Transform = transform;
            _text = text;
            _spriteRenderer = spriteRenderer;
        }


        public void UpdateValue(int value)
        {
            _text.text = value.ToString();
            _text.color = ColorExtensions.GetTileTextColorByNumber(value);
            _spriteRenderer.color = ColorExtensions.GetTileColorByNumber(value);
        }
        // TODO : Maybe object shouldn't destroy itself?
        public void Destroy()
        {
            Object.Destroy(Transform.gameObject);
        }
    }
}