﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TwinStickZombie
{
    class Armory
    {
        public static Weapon CreatePistol(string name)
        {
            List<Texture2D> frames = new List<Texture2D>();
            frames.Add(Art.PistolShoot1);
            frames.Add(Art.PistolShoot2);
            frames.Add(Art.PistolShoot3);

            int damage = 3;
            int cooldown = 20;
            float bulletSpeed = 20f;
            Weapon.Mode mode = Weapon.Mode.Auto;

            return new Weapon(name, cooldown, damage, bulletSpeed, mode, frames, 10, Animation.Mode.OnDemand);
        }
    }
}