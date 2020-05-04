using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie.Shared
{
    abstract class Entity
    {
        protected Texture2D image;
        protected Color colour = Color.White;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;
        public float Radius = 20;
        public bool IsExpired;

        public Vector2 Size
        {
            get
            {
                if (image == null)
                {
                    return Vector2.Zero;

                }
                else
                {
                    return new Vector2(image.Width, image.Height);
                }
            }
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, colour, Orientation, Size/2f, 1f, 0,0);
        }
    }
}
