using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    class Art
    {
        public static Texture2D PlayerIdle1;
        public static Texture2D PlayerIdle2;
        public static Texture2D PlayerIdle3;

        public static Texture2D PlayerRun1;
        public static Texture2D PlayerRun2;
        public static Texture2D PlayerRun3;
        public static Texture2D PlayerRun4;

        public static Texture2D ZombieIdle1;
        public static Texture2D ZombieIdle2;
        public static Texture2D ZombieIdle3;

        public static Texture2D Bullet;
        public static Texture2D Pointer;

        public static void Load(GameRoot instance)
        {
            PlayerIdle1 = instance.Content.Load<Texture2D>("art\\player_idle_1");
            PlayerIdle2 = instance.Content.Load<Texture2D>("art\\player_idle_2");
            PlayerIdle3 = instance.Content.Load<Texture2D>("art\\player_idle_3");

            PlayerRun1 = instance.Content.Load<Texture2D>("art\\player_run_1");
            PlayerRun2 = instance.Content.Load<Texture2D>("art\\player_run_2");
            PlayerRun3 = instance.Content.Load<Texture2D>("art\\player_run_3");
            PlayerRun4 = instance.Content.Load<Texture2D>("art\\player_run_4");

            ZombieIdle1 = instance.Content.Load<Texture2D>("art\\zombie_idle_1");
            ZombieIdle2 = instance.Content.Load<Texture2D>("art\\zombie_idle_2");
            ZombieIdle3 = instance.Content.Load<Texture2D>("art\\zombie_idle_3");

            Bullet = instance.Content.Load<Texture2D>("art\\Bullet");
            Pointer = instance.Content.Load<Texture2D>("art\\Pointer");
        }
    }
}
