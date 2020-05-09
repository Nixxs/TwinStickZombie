using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TwinStickZombie
{
    class Weapon : Entity
    {
        private static Animation _animation;
        public string Name { get; private set; }
        private SpriteEffects _flipDirection;
        private int _damage;
        private int _cooldown;
        private Mode _mode;

        public enum Mode
        {
            Auto,
            Single
        }

        public enum Type
        {
            Pistol,
            Rifle
        }

        public Weapon(string name, int cooldown, int damage, Mode mode, List<Texture2D> animationFrames, int animationSpeed, Animation.Mode animationMode)
        {
            _animation = new Animation(animationFrames, animationSpeed, animationMode);

            image = _animation.CurrentFrame;
            IsExpired = false;
            Velocity = Vector2.Zero;
        }

        // genrate the bullet and play the animation
        public void Shoot()
        {
            _animation.Play = true;
        }

        //update is jsut for the weapons postion and orientation update
        // also to update the animation
        public override void Update()
        {
            Position = Player.Instance.Position;
            image = _animation.CurrentFrame;

            // if the player is moving left, flip the image
            if (Input.GetMovementDirection().X < 0)
            {
                _flipDirection = SpriteEffects.FlipHorizontally;
            }
            if (Input.GetMovementDirection().X > 0)
            {
                _flipDirection = SpriteEffects.None;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size / 2f, 1f, _flipDirection, 0);
        }
    }
}
