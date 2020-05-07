using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TwinStickZombie
{
    class Camera
    {
        public static Matrix Transform { get; private set; }

        private static Matrix _position;
        private static Matrix _offset;

        public static float ZoomFactor = 2;
        private static Matrix _zoom;

        public static Vector2 CameraPosition;

        private Camera()
        {
            CameraPosition = new Vector2(
                    Player.Instance.Position.X - (Player.Instance.Size.X / 2),
                    Player.Instance.Position.Y - (Player.Instance.Size.Y / 2)
                );
        }

        private static Vector2 GetCameraPosition()
        {
            // set camera position changes here at the moment it is just set to the 
            // center of the player
            float xpos = Player.Instance.Position.X - (Player.Instance.Size.X / 2);
            float ypos = Player.Instance.Position.Y - (Player.Instance.Size.Y / 2);

            return new Vector2( xpos, ypos);
        }

        public static void Update()
        {
            CameraPosition = GetCameraPosition();

            _position = Matrix.CreateTranslation(
                -CameraPosition.X,
                -CameraPosition.Y,
                0f);

            _offset = Matrix.CreateTranslation(
                    GameRoot.ScreenSize.X / 2, 
                    GameRoot.ScreenSize.Y / 2, 
                    0);

            _zoom = Matrix.CreateScale(new Vector3(ZoomFactor, ZoomFactor, 1));

            Transform = _position * _zoom * _offset; 
        }
    }
}
