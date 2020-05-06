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
    }
}
