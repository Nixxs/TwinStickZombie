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
            Speed = 4f;
        }

        public override void Update()
        {
            // this is movement code, needs to be updated to use forces instead of this direct movement method
            // the current input is added to the current velocity this introduces inertia
            // the friction is applied to the overall force to counter it. eventually
            // if no input direction force is provided the velocity value will go to zero
            Velocity = (Velocity + (Input.GetMovementDirection() * Speed)) * World.Friction;
            Position = Position + Velocity;

            // clamps the player to the screen size, this can be extended later to create larger
            // maps if needed
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);
            
        }
    }
}
