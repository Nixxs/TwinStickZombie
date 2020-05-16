using System;
using System.Collections.Generic;
using System.Text;

namespace TwinStickZombie.Enemy
{
    class Behaviours
    {
        //behaviours
        public static IEnumerable<int> FollowPlayer(Entity enemy, float acceleration = 1f)
        {
            while (true)
            {
                enemy.Velocity += (Player.Instance.Position - enemy.Position).ScaleTo(acceleration);
                yield return 0;
            }
        }
    }
}
