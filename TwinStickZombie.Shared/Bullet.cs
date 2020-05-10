using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

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
            colour = Color.Ivory;
        }

        public override void Update()
        {
            if (Velocity.LengthSquared() > 0)
            {
                Orientation = Velocity.ToAngle();
            }

            Position += Velocity;

            // delete bullets that leave the boundary of the world
            if (!MathUtil.Contains(Position, Vector2.Zero, World.Size))
            {
                IsExpired = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
