using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    class Player : Entity
    {
        private static Animation _animationIdle;
        private static List<Texture2D> _idleFrames = new List<Texture2D>();

        private static Animation _animationMoving;
        private static List<Texture2D> _movingFrames = new List<Texture2D>();

        private SpriteEffects _flipDirection;

        public Weapon PrimaryWeapon = Armory.CreatePistol("Glock");

        private static Player _instance;
        public static Player Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Player();
                }

                return _instance;
            }
        }

        private Player()
        {
            _idleFrames.Add(Art.PlayerIdle1);
            _idleFrames.Add(Art.PlayerIdle2);
            _idleFrames.Add(Art.PlayerIdle3);
            _animationIdle = new Animation(_idleFrames, 10, Animation.Mode.Looping);

            _movingFrames.Add(Art.PlayerRun1);
            _movingFrames.Add(Art.PlayerRun2);
            _movingFrames.Add(Art.PlayerRun3);
            _movingFrames.Add(Art.PlayerRun4);
            _animationMoving = new Animation(_movingFrames, 10, Animation.Mode.Looping);

            image = _animationIdle.CurrentFrame;
            Position = GameRoot.ScreenSize / 2;
            Radius = 10;
            Speed = 4f;
        }

        private bool IsMoving
        {
            get
            {
                if (Input.GetMovementDirection() != Vector2.Zero)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Update()
        {
            // update the player animations
            _animationIdle.Update();
            _animationMoving.Update();

            // if the player is moving use the running animation otherwise use idle
            if (IsMoving)
            {
                image = _animationMoving.CurrentFrame;
            } else
            {
                image = _animationIdle.CurrentFrame;
            }

            // if the player is moving left, flip the image
            if (Input.GetMovementDirection().X < 0)
            {
                _flipDirection = SpriteEffects.FlipHorizontally;
            }
            if (Input.GetMovementDirection().X > 0)
            {
                _flipDirection = SpriteEffects.None;
            }

            // here we update the weapons
            PrimaryWeapon.Update();

            // this is movement code, needs to be updated to use forces instead of this direct movement method
            // the current input is added to the current velocity this introduces inertia
            // the friction is applied to the overall force to counter it. eventually
            // if no input direction force is provided the velocity value will go to zero
            Velocity = (Velocity + (Input.GetMovementDirection() * Speed)) * World.Friction;
            Position = Position + Velocity;

            // clamps the player to the screen size, this can be extended later to create larger
            // maps if needed
            Position = Vector2.Clamp(Position, Size / 2, World.Size - Size / 2);
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            PrimaryWeapon.Draw(spriteBatch);
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size / 2f, 1f, _flipDirection, 0);
        }
    }
}
