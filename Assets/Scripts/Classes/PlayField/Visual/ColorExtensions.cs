using System.Collections.Generic;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public static class ColorExtensions
    {
        private static readonly Dictionary<int, Color> NumberToColorDictionary = new Dictionary<int, Color>()
        {
            [2] = new Color32(238, 228, 218, 255),
            [4] = new Color32(237, 224, 200, 255),
            [8] = new Color32(242, 177, 121, 255),
            [16] = new Color32(245, 149, 99, 255),
            [32] = new Color32(246, 124, 96, 255),
            [64] = new Color32(246, 94, 59, 255),
            [128] = new Color32(237, 207, 115, 255),
            [256] = new Color32(237, 204, 98, 255),
            [512] = new Color32(237, 200, 80, 255),
            [1024] = new Color32(237, 197, 63, 255),
            [2048] = new Color32(237, 194, 45, 255),
        };

        private static readonly Color TileTextColorForLessThan8 = new Color32(119, 110, 101, 255);
        private static readonly Color TileTextColorForMoreThan8 = new Color32(249, 246, 242, 255);
        

        public static Color GetTileColorByNumber(int number)
        {
            return NumberToColorDictionary[number];
        }
        public static Color GetTileTextColorByNumber(int number)
        {
            return number < 8 ? TileTextColorForLessThan8 : TileTextColorForMoreThan8;
        }
    }
}