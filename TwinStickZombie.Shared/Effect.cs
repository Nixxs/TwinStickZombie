﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    class Effect : Entity
    {
        private static Animation _animation;

        public enum Type
        {
            Explosion,
            Impact
        }

        public Effect(Vector2 position, List<Texture2D> animationFrames, int animationSpeed, Animation.Mode animationMode)
        {
            _animation = new Animation(animationFrames, animationSpeed, animationMode);

            image = _animation.CurrentFrame;
            Position = position;
            Velocity = Vector2.Zero;
            IsExpired = false;
            _animation.Play = true;
        }

        public override void Update()
        {
            _animation.Update();
            image = _animation.CurrentFrame;

            // if playsingle has been set to false expire this entity
            if (!_animation.Play)
            {
                IsExpired = true;
            }
        }

        public static void CreateEffect(Vector2 position, Type type)
        {
            switch (type)
            {
                case Type.Explosion:
                    List<Texture2D> explosionFrames = new List<Texture2D>();
                    explosionFrames.Add(Art.Explosion1);
                    explosionFrames.Add(Art.Explosion2);
                    explosionFrames.Add(Art.Explosion3);
                    explosionFrames.Add(Art.Explosion4);
                    explosionFrames.Add(Art.Explosion5);
                    explosionFrames.Add(Art.Explosion6);
                    explosionFrames.Add(Art.Explosion7);
                    explosionFrames.Add(Art.Explosion8);

                    Effect explosion = new Effect(position, explosionFrames, 5, Animation.Mode.OnDemand);
                    EntityManager.Add(explosion);
                    break;
                case Type.Impact:
                    List<Texture2D> impactFrames = new List<Texture2D>();
                    impactFrames.Add(Art.Impact1);
                    impactFrames.Add(Art.Impact2);
                    impactFrames.Add(Art.Impact3);
                    impactFrames.Add(Art.Impact4);
                    impactFrames.Add(Art.Impact5);

                    Effect impact = new Effect(position, impactFrames, 3, Animation.Mode.OnDemand);
                    EntityManager.Add(impact);
                    break;
                default:
                    break;
            }
        }
    }
}
