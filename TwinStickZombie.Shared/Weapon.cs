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

        private int _cooldownRemaining = 0;
        private int _damage;
        private int _cooldown;
        private Mode _mode;
        private float _bulletSpeed;
        private float _recoil;
        private Vector2 _crossHairPosition;

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

        public Weapon(string name, int cooldown, int damage, float bulletSpeed, float recoil, Mode mode, List<Texture2D> animationFrames, int animationSpeed, Animation.Mode animationMode)
        {
            _animation = new Animation(animationFrames, animationSpeed, animationMode);

            _mode = mode;
            _cooldown = cooldown;
            image = _animation.CurrentFrame;
            IsExpired = false;
            Velocity = Vector2.Zero;
            _bulletSpeed = bulletSpeed;
            _recoil = recoil;
            _damage = damage;
        }

        // genrate the bullet and play the animation
        private void Shoot()
        {
            if (_cooldownRemaining <= 0)
            {
                _animation.Play = true;
                _animation.FrameIndex = 1;

                _cooldownRemaining = _cooldown;

                var aim = Input.GetAimDirection() + new Vector2(0, -0.03f);
                float aimAngle = aim.ToAngle();
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                Vector2 vel = MathUtil.FromPolar(aimAngle, _bulletSpeed);

                Vector2 offset = Vector2.Zero;
                if (aim.X < 0)
                {
                    offset = Vector2.Transform(new Vector2(25, 10), aimQuat);
                }
                else
                {
                    offset = Vector2.Transform(new Vector2(25, -10), aimQuat);
                }

                EntityManager.Add(new Bullet(Position + offset, vel, _damage));

                // handle the recoil
                Player.Instance.Velocity += MathUtil.FromPolar((Player.Instance.Position - Position).ToAngle(), _recoil);
            }
        }

        //update is jsut for the weapons postion and orientation update
        // also to update the animation
        public override void Update()
        {
            // positioning the weapon for drawing on the screen
            var aim = Input.GetAimDirection();
            float aimAngle = aim.ToAngle();
            Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
            Vector2 offset = Vector2.Transform(new Vector2(20, 0), aimQuat) + new Vector2(0, 10);
            Orientation = aimAngle;

            Position = Player.Instance.Position + offset;

            // handle the weapons animations
            _animation.Update();
            image = _animation.CurrentFrame;

            if (aim.X < 0)
            {
                _flipDirection = SpriteEffects.FlipVertically;
            }
            if (aim.X > 0)
            {
                _flipDirection = SpriteEffects.None;
            }

            // handle firing mode, if its a single shot weapon then only fire on individual button presses 
            if (Input.WasShootButtonPressed(_mode))
            {
                Shoot();
            }

            // reduce the cooldown remaining by 1 frame so it can shoot again
            if (_cooldownRemaining > 0)
            {
                _cooldownRemaining -= 1;
            }

            // update crosshair position
            if (aim.X < 0)
            {
                _crossHairPosition = Position + Vector2.Transform(new Vector2(150, 15), aimQuat);
            }
            if (aim.X > 0)
            {
                _crossHairPosition = Position + Vector2.Transform(new Vector2(150, -15), aimQuat);
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size / 2f, 1f, _flipDirection, 1);

            // only draw the crosshair if player is not moving
            if (!Player.Instance.IsMoving)
            {
                spriteBatch.Draw(Art.Pointer, _crossHairPosition, null, Color.White);
            }
        }
    }
}
