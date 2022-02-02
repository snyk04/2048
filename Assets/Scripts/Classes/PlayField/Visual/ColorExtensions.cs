using System;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public static class ColorExtensions
    {
        private static readonly Color TileColorFor2 = new Color32(238, 228, 218, 255);
        private static readonly Color TileColorFor4 = new Color32(237, 224, 200, 255);
        private static readonly Color TileColorFor8 = new Color32(242, 177, 121, 255);
        private static readonly Color TileColorFor16 = new Color32(245, 149, 99, 255);
        private static readonly Color TileColorFor32 = new Color32(246, 124, 96, 255);
        private static readonly Color TileColorFor64 = new Color32(246, 94, 59, 255);
        private static readonly Color TileColorFor128 = new Color32(237, 207, 115, 255);
        private static readonly Color TileColorFor256 = new Color32(237, 204, 98, 255);
        private static readonly Color TileColorFor512 = new Color32(237, 200, 80, 255);
        private static readonly Color TileColorFor1024 = new Color32(237, 197, 63, 255);
        private static readonly Color TileColorFor2048 = new Color32(237, 194, 45, 255);
        
        private static readonly Color TileTextColorForLessThan8 = new Color32(119, 110, 101, 255);
        private static readonly Color TileTextColorForMoreThan8 = new Color32(249, 246, 242, 255);
        

        // TODO : Maybe move it to dictionary?
        public static Color GetTileColorByNumber(int number)
        {
            return number switch
            {
                2 => TileColorFor2,
                4 => TileColorFor4,
                8 => TileColorFor8,
                16 => TileColorFor16,
                32 => TileColorFor32,
                64 => TileColorFor64,
                128 => TileColorFor128,
                256 => TileColorFor256,
                512 => TileColorFor512,
                1024 => TileColorFor1024,
                2048 => TileColorFor2048,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public static Color GetTileTextColorByNumber(int number)
        {
            return number < 8 ? TileTextColorForLessThan8 : TileTextColorForMoreThan8;
        }
    }
}