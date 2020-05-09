using Microsoft.Xna.Framework;

namespace TwinStickZombie
{
    class Bullet : Entity
    {
        public Bullet(Vector2 position, Vector2 velocity)
        {
            image = Art.Bullet;
            Position = position;
            Velocity = velocity;
            Orientation = Velocity.ToAngle();
            Radius = 4;
        }

        public override void Update()
        {
            if (Velocity.LengthSquared() > 0)
            {
                Orientation = Velocity.ToAngle();
            }

            Position += Velocity;

            // delete bullets that leave the boundary of the world
            if (!Extensions.Contains(Position, Vector2.Zero, World.Size))
            {
                IsExpired = true;
            }
        }
    }
}
