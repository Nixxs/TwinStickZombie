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
            int movementCooldown = 100;
            int cooldownState = 0;
            while (true)
            {
                if (cooldownState == 0)
                {
                    enemy.Velocity += (Player.Instance.Position - enemy.Position).ScaleTo(acceleration);
                    cooldownState = movementCooldown;
                }

                if (cooldownState >= 0)
                {
                    cooldownState -= 1;
                }

                yield return 0;
            }
        }
    }
}
