using System;
using System.Collections.Generic;
using System.Text;

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
            //throw new NotImplementedException();
        }
    }
}
