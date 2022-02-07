using TMPro;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public class TileVisual
    {
        public Transform Transform { get; }
        public SpriteRenderer SpriteRenderer { get; }
        public TextMeshPro Text { get; }
        
        public Vector3 CurrentPosition { get; set; }
        
        
        public TileVisual(Transform transform, TextMeshPro text, SpriteRenderer spriteRenderer)
        {
            Transform = transform;
            SpriteRenderer = spriteRenderer;
            Text = text;
        }


        public void UpdateValue(int value)
        {
            Text.text = value.ToString();
            Text.color = ColorExtensions.GetTileTextColorByNumber(value);
            SpriteRenderer.color = ColorExtensions.GetTileColorByNumber(value);
        }
    }
}