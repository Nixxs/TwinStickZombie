using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TwinStickZombie
{
    static class Debug
    {
        public static void Update()
        {
            //DEBUG START
            if (Input.WasKeyPressed(Keys.F1))
            {
                Effect.CreateEffect(Input.MousePosition, Effect.Type.Explosion);
            }

            if (Input.WasKeyPressed(Keys.F2))
            {
                Effect.CreateEffect(Input.MousePosition, Effect.Type.Impact);
            }


            
            //DEBUG END
        }
    }
}
