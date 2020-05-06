using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    class Player : Entity
    {
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
            image = Art.Player;
            Position = GameRoot.ScreenSize / 2;
            Radius = 10;
        }

        public override void Update()
        {
            // this is movement code, needs to be updated to use forces instead of this direct movement method
            float speed = 8;
            Velocity = speed * Input.GetMovementDirection();
            Position = Position + Velocity;

            // clamps the player to the screen size
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);
            
        }
    }
}
