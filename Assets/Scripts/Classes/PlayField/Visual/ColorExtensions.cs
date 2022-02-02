using System;
using UnityEngine;

namespace TwentyFortyEight.PlayField.Visual
{
    public static class ColorExtensions
    {
        private static readonly Color ColorFor2 = new Color(238/255f, 228/255f, 218/255f);
        private static readonly Color ColorFor4 = new Color(237/255f, 224/255f, 200/255f);
        private static readonly Color ColorFor8 = new Color(242/255f, 177/255f, 121/255f);
        private static readonly Color ColorFor16 = new Color(245/255f, 149/255f, 99/255f);
        private static readonly Color ColorFor32 = new Color(246/255f, 124/255f, 96/255f);
        private static readonly Color ColorFor64 = new Color(246/255f, 94/255f, 59/255f);
        private static readonly Color ColorFor128 = new Color(237/255f, 207/255f, 115/255f);
        private static readonly Color ColorFor256 = new Color(237/255f, 204/255f, 98/255f);
        private static readonly Color ColorFor512 = new Color(237/255f, 200/255f, 80/255f);
        private static readonly Color ColorFor1024 = new Color(237/255f, 197/255f, 63/255f);
        private static readonly Color ColorFor2048 = new Color(237/255f, 194/255f, 45/255f);
        

        public static Color GetColorByNumber(int number)
        {
            return number switch
            {
                2 => ColorFor2,
                4 => ColorFor4,
                8 => ColorFor8,
                16 => ColorFor16,
                32 => ColorFor32,
                64 => ColorFor64,
                128 => ColorFor128,
                256 => ColorFor256,
                512 => ColorFor512,
                1024 => ColorFor1024,
                2048 => ColorFor2048,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}