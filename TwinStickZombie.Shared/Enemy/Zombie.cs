using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie.Enemy
{
    class Zombie : Entity
    {
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

        private Animation _animationIdle;
        private List<Texture2D> _idleFrames = new List<Texture2D>();

        private Animation _animationMoving;
        private List<Texture2D> _movingFrames = new List<Texture2D>();

        private Animation _animationAttack;
        private List<Texture2D> _attackFrames = new List<Texture2D>();

        private Animation _animationDie;
        private List<Texture2D> _dieFrames = new List<Texture2D>();

        private SpriteEffects _flipDirection;
        private static Vector2 _previousPosition;

        private int timeUntilStart = 60;
        public bool IsActive
        {
            get
            {
                return timeUntilStart <= 0;
            }
        }

        public Zombie(Vector2 position)
        {
            _idleFrames.Add(Art.ZombieIdle1);
            _idleFrames.Add(Art.ZombieIdle2);
            _idleFrames.Add(Art.ZombieIdle3);
            _animationIdle = new Animation(_idleFrames, 10, Animation.Mode.Looping);

            _movingFrames.Add(Art.ZombieRun1);
            _movingFrames.Add(Art.ZombieRun2);
            _movingFrames.Add(Art.ZombieRun3);
            _movingFrames.Add(Art.ZombieIdle1);
            _movingFrames.Add(Art.ZombieIdle2);
            _movingFrames.Add(Art.ZombieIdle3);
            _movingFrames.Add(Art.ZombieIdle2);
            _animationMoving = new Animation(_movingFrames, 10, Animation.Mode.OnDemand);

            _attackFrames.Add(Art.ZombieAttack1);
            _attackFrames.Add(Art.ZombieAttack2);
            _attackFrames.Add(Art.ZombieAttack3);
            _attackFrames.Add(Art.ZombieAttack4);
            _attackFrames.Add(Art.ZombieAttack5);
            _animationAttack = new Animation(_attackFrames, 10, Animation.Mode.OnDemand);

            image = _animationIdle.CurrentFrame;
            Position = position;
            Radius = image.Width / 2f;
            colour = Color.Transparent;
        }

        private void AddBehavior(IEnumerable<int> behavior)
        {
            behaviours.Add(behavior.GetEnumerator());
        }

        private void ApplyBehaviours()
        {
            for(int i = 0; i < behaviours.Count; i++)
            {
                if (behaviours[i].MoveNext() == false)
                {
                    // remove behaviour enumerator if its finsihed 
                    behaviours.RemoveAt(i--);
                }
            }
        }

        public bool IsMoving()
        {
            if (Position != _previousPosition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Update()
        {
            _previousPosition = Position;

            if (IsActive)
            {
                ApplyBehaviours();
            }
            else
            {
                timeUntilStart -= 1;
                // makes it less transparent every frame until its completely opaque
                colour = Color.White * (1 - timeUntilStart / 60f);
            }

            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, World.Size - Size / 2);

            Velocity *= 0.8f;

            // update the animation
            _animationMoving.Update();
            _animationIdle.Update();
            _animationAttack.Update();

            if (_animationMoving.Play)
            {
                image = _animationMoving.CurrentFrame;
            }

            if (_animationAttack.Play)
            {
                image = _animationAttack.CurrentFrame;
            }

            if ((_animationAttack.Play || _animationMoving.Play) == false)
            {
                image = _animationIdle.CurrentFrame;
            }

            // handle flip direction
            if ((Player.Instance.Position - Position).X > 0)
            {
                _flipDirection = SpriteEffects.None;
            }
            else
            {
                _flipDirection = SpriteEffects.FlipHorizontally;
            }
        }

        public void WasShot()
        {
            IsExpired = true;
        }

        public static Zombie Create(Vector2 position)
        {
            Zombie zombie = new Zombie(position);
            zombie.AddBehavior(FollowPlayer(zombie , 4f));

            return zombie;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size / 2f, 1f, _flipDirection, 0);
        }

        private float GetDistanceToPlayer()
        {
            return Vector2.Distance(Position, Player.Instance.Position);
        }

        public static IEnumerable<int> FollowPlayer(Enemy.Zombie enemy, float acceleration = 1f)
        {
            int movementCooldown = 6;
            int cooldownState = 0;

            while (true)
            {
                // if zombie is far from player then move to player
                if (enemy.GetDistanceToPlayer() >= 100)
                {
                    // move toward player
                    if (cooldownState == 0 && enemy._animationAttack.Play == false)
                    {
                        enemy._animationMoving.Play = true;
                        enemy._animationIdle.FrameIndex = 0;
                        if (enemy._animationMoving.FrameIndex == 2)
                        {
                            enemy.Velocity += (Player.Instance.Position - enemy.Position).ScaleTo(acceleration);
                            cooldownState = movementCooldown;
                        }
                    }
                }
                else
                // attack player
                {
                    // move toward player
                    if (cooldownState == 0)
                    {
                        enemy._animationAttack.Play = true;
                        enemy._animationIdle.FrameIndex = 0;

                        if (enemy._animationAttack.FrameIndex == 3)
                        {
                            Vector2 attackDirection = Vector2.Normalize((Player.Instance.Position - enemy.Position)) * 5f;
                            enemy.Velocity += attackDirection;
                            cooldownState = movementCooldown;
                        }
                    }
                }


                if (cooldownState > 0)
                {
                    cooldownState -= 1;
                }

                yield return 0;
            }
        }

    }
}
