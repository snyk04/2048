using System;
using System.Collections.Generic;
using TwentyFortyEight.PlayField.Logic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TwentyFortyEight.Common
{
    public static class Vector2Extensions
    {
        private static readonly Dictionary<Vector2, Direction> Vector2ToDirection = new Dictionary<Vector2, Direction>
        {
            [Vector2.up] = Direction.Up,
            [Vector2.right] = Direction.Right,
            [Vector2.down] = Direction.Down,
            [Vector2.left] = Direction.Left
        };
        
        public static Direction GetDirection(this Vector2 vector2)
        {
            Vector2 snappedVector = vector2.SnapToAxis();
            return Vector2ToDirection[snappedVector.normalized];
        }
        
        public static Vector2 SnapToAxis(this ref Vector2 vector)
        {
            float xAbs = Mathf.Abs(vector.x);
            float yAbs = Mathf.Abs(vector.y);

            switch (xAbs.CompareTo(yAbs))
            {
                case 1:
                    return vector.SnapToX();
                case -1:
                    return vector.SnapToY();
                case 0:
                    return Random.value > 0.5f ? vector.SnapToX() : vector.SnapToY();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Vector2 SnapToX(this ref Vector2 vector)
        {
            return vector = new Vector2(Mathf.Sign(vector.x), 0.0f);
        }
        public static Vector2 SnapToY(this ref Vector2 vector)
        {
            return vector = new Vector2(0.0f, Mathf.Sign(vector.y));
        }
    }
}