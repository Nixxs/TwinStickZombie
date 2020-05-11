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

        public static Vector2 ScaleTo(this Vector2 vector, float length)
        {
            // multiplying the given vector by the fraction of it's length
            return vector * (length / vector.Length());
        }
    }
}
