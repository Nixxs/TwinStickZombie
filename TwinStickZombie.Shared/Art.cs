﻿using Microsoft.Xna.Framework.Graphics;

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

        public static Texture2D ZombieRun1;
        public static Texture2D ZombieRun2;
        public static Texture2D ZombieRun3;

        public static Texture2D ZombieAttack1;
        public static Texture2D ZombieAttack2;
        public static Texture2D ZombieAttack3;
        public static Texture2D ZombieAttack4;
        public static Texture2D ZombieAttack5;

        public static Texture ZombieDie1;
        public static Texture ZombieDie2;
        public static Texture ZombieDie3;
        public static Texture ZombieDie4;
        public static Texture ZombieDie5;

        public static Texture2D Explosion1;
        public static Texture2D Explosion2;
        public static Texture2D Explosion3;
        public static Texture2D Explosion4;
        public static Texture2D Explosion5;
        public static Texture2D Explosion6;
        public static Texture2D Explosion7;
        public static Texture2D Explosion8;

        public static Texture2D Impact1;
        public static Texture2D Impact2;
        public static Texture2D Impact3;
        public static Texture2D Impact4;
        public static Texture2D Impact5;

        public static Texture2D PistolShoot1;
        public static Texture2D PistolShoot2;
        public static Texture2D PistolShoot3;

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

            ZombieIdle1 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_idle_1");
            ZombieIdle2 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_idle_2");
            ZombieIdle3 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_idle_3");

            ZombieRun1 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_run_1");
            ZombieRun2 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_run_2");
            ZombieRun3 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_run_3");

            ZombieAttack1 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_attack_1");
            ZombieAttack2 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_attack_2");
            ZombieAttack3 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_attack_3");
            ZombieAttack4 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_attack_4");
            ZombieAttack5 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_attack_5");

            ZombieDie1 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_headshot_1");
            ZombieDie2 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_headshot_2");
            ZombieDie3 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_headshot_3");
            ZombieDie4 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_headshot_4");
            ZombieDie5 = instance.Content.Load<Texture2D>("art\\enemy\\zombie\\zombie_headshot_5");

            Explosion1 = instance.Content.Load<Texture2D>("effect\\explosion2_1");
            Explosion2 = instance.Content.Load<Texture2D>("effect\\explosion2_2");
            Explosion3 = instance.Content.Load<Texture2D>("effect\\explosion2_3");
            Explosion4 = instance.Content.Load<Texture2D>("effect\\explosion2_4");
            Explosion5 = instance.Content.Load<Texture2D>("effect\\explosion2_5");
            Explosion6 = instance.Content.Load<Texture2D>("effect\\explosion2_6");
            Explosion7 = instance.Content.Load<Texture2D>("effect\\explosion2_7");
            Explosion8 = instance.Content.Load<Texture2D>("effect\\explosion2_8");

            Impact1 = instance.Content.Load<Texture2D>("effect\\impact4_1");
            Impact2 = instance.Content.Load<Texture2D>("effect\\impact4_2");
            Impact3 = instance.Content.Load<Texture2D>("effect\\impact4_3");
            Impact4 = instance.Content.Load<Texture2D>("effect\\impact4_4");
            Impact5 = instance.Content.Load<Texture2D>("effect\\impact4_5");

            PistolShoot1 = instance.Content.Load<Texture2D>("art\\pistol_shoot_1");
            PistolShoot2 = instance.Content.Load<Texture2D>("art\\pistol_shoot_2");
            PistolShoot3 = instance.Content.Load<Texture2D>("art\\pistol_shoot_3");

            Bullet = instance.Content.Load<Texture2D>("art\\Bullet");
            Pointer = instance.Content.Load<Texture2D>("art\\Pointer");
        }
    }
}
