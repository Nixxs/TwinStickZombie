using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie.Enemy
{
    class Zombie : Entity
    {
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

        private static Animation _animationIdle;
        private static List<Texture2D> _idleFrames = new List<Texture2D>();

        private static Animation _animationMoving;
        private static List<Texture2D> _movingFrames = new List<Texture2D>();

        private static Animation _animationAttack;
        private static List<Texture2D> _attackFrames = new List<Texture2D>();

        private static Animation _animationDie;
        private static List<Texture2D> _dieFrames = new List<Texture2D>();

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

        public override void Update()
        {
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


            _animationIdle.Update();
            image = _animationIdle.CurrentFrame;
        }

        public void WasShot()
        {
            IsExpired = true;
        }

        public static Zombie Create(Vector2 position)
        {
            Zombie zombie = new Zombie(position);
            zombie.AddBehavior(Behaviours.FollowPlayer(zombie, 0.25f));

            return zombie;
        }

    }
}
