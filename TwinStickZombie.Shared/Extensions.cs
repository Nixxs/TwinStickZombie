using Microsoft.Xna.Framework;
using System;

namespace TwinStickZombie
{
    public static class Extensions
    {
        // converts a given vector to an angle
        public static float ToAngle(this Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

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
    }
}
