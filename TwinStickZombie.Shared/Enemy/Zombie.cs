using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie.Enemy
{
    class Zombie : Entity
    {
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();

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
            image = Art.ZombieIdle1;
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
        }

        public void WasShot()
        {
            IsExpired = true;
        }


        public static Zombie CreateZombie(Vector2 position)
        {
            Zombie zombie = new Zombie(position);
            zombie.AddBehavior(zombie.FollowPlayer());

            return zombie;
        }

        //behaviours
        IEnumerable<int> FollowPlayer(float acceleration = 1f)
        {
            while (true)
            {
                Velocity += (Player.Instance.Position - Position).ScaleTo(acceleration);
                yield return 0;
            }
        }
    }
}
