using Microsoft.Xna.Framework;
using System;

namespace TwinStickZombie
{
    public static class MathUtil
    {
        // checks if a given point is within a min or max bounds
        public static bool Contains(Vector2 point, Vector2 min, Vector2 max)
        {
            if ((point.X >= min.X) && (point.Y >= min.Y) && (point.X <= max.X) && (point.Y <= max.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // returns a vector from a given angle and magnitude
        public static Vector2 FromPolar(float angle, float magnitude)
        {
            return magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        // gets the opposite angle from an given angle
        public static float OppositeAngle(float angle)
        {
            return (angle + 180) % 360;
        }
    }
}
