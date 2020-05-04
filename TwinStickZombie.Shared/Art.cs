using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    class Art
    {
        private static Texture2D _player;
        public static Texture2D Player
        {
            get
            {
                return _player;
            }
        }

        private static Texture2D _zombie;
        public static Texture2D Zombie
        {
            get
            {
                return _zombie;
            }
        }

        private static Texture2D _bullet;
        public static Texture2D Bullet
        {
            get
            {
                return _bullet;
            }
        }

        private static Texture2D _pointer;
        public static Texture2D Pointer
        {
            get
            {
                return _pointer;
            }
        }

        public static void Load(GameRoot instance)
        {
            _player = instance.Content.Load<Texture2D>("art\\Player");
            _zombie = instance.Content.Load<Texture2D>("art\\Seeker");
            _bullet = instance.Content.Load<Texture2D>("art\\Bullet");
            _pointer = instance.Content.Load<Texture2D>("art\\Pointer");
        }
    }
}
