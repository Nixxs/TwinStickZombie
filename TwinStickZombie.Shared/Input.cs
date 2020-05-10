using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TwinStickZombie
{
    static class Input
    {
        private static KeyboardState _keyboardState;
        private static KeyboardState _lastKeyboardState;

        private static MouseState _mouseState;
        private static MouseState _lastMouseState;

        private static GamePadState _gamePadState;
        private static GamePadState _lastGamePadState;

        private static Vector2 _lastAimDirection;
        private static Vector2 _aimDirection;
        private static bool isAimingWithMouse = false;

        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(_mouseState.X, _mouseState.Y);
            }
        }

        public static void Update()
        {
            _lastKeyboardState = _keyboardState;
            _lastMouseState = _mouseState;
            _lastGamePadState = _gamePadState;

            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
            _gamePadState = GamePad.GetState(PlayerIndex.One);

            // check if the mouse is being used or not and updates accordingly
            if (_gamePadState.ThumbSticks.Right != Vector2.Zero || _lastMouseState.Position == _mouseState.Position)
            {
                isAimingWithMouse = false;
            }
            else
            {
                isAimingWithMouse = true;
            }
        }

        // if thekey wa up in the previous state and it's down down then it must mean it 
        // was just pressed
        public static bool WasKeyPressed(Keys key)
        {
            if (_lastKeyboardState.IsKeyUp(key) && _keyboardState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool WasButtonPressed(Buttons button)
        {
            if (_lastGamePadState.IsButtonUp(button) && _gamePadState.IsButtonDown(button))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool WasMouseLeftButtonPressed()
        {
            if (_lastMouseState.LeftButton == ButtonState.Released && _mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Vector2 GetMovementDirection()
        {
            // the thumstick returns a positive value when the player pushes it up
            // but the screen coordinates start in the top left so if you want to go upwards
            // you need to subtract from the current Y axis position (ie approach 0)
            Vector2 direction = _gamePadState.ThumbSticks.Left;
            direction.Y *= -1; //inverts the Y axis

            if (_keyboardState.IsKeyDown(Controls.Left))
            {
                direction.X -= 1;
            }
            if (_keyboardState.IsKeyDown(Controls.Right))
            {
                direction.X += 1;
            }
            if (_keyboardState.IsKeyDown(Controls.Up))
            {
                direction.Y -= 1;
            }
            if (_keyboardState.IsKeyDown(Controls.Down))
            {
                direction.Y += 1;
            }

            // Clamp the length of the vector to a max of 1
            if (direction.LengthSquared() > 1)
            {
                direction.Normalize();
            }

            return direction;
        }

        private static Vector2 GetMouseAimDirection()
        {
            _aimDirection = MousePosition - Player.Instance.Position;
            _aimDirection = Vector2.Normalize(_aimDirection);
            return _aimDirection;
        }

        public static Vector2 GetAimDirection()
        {
            if (!(_aimDirection == Vector2.Zero))
            {
                _lastAimDirection = _aimDirection;
            }

            if (isAimingWithMouse)
            {
                return GetMouseAimDirection();
            }

            _aimDirection = _gamePadState.ThumbSticks.Right;
            _aimDirection.Y *= -1;

            if (_aimDirection == Vector2.Zero)
            {
                return _lastAimDirection;
            }
            else
            {
                _aimDirection = Vector2.Normalize(_aimDirection);
                return _aimDirection;
            }
        }

        public static bool WasShootButtonPressed(Weapon.Mode mode)
        {
            switch(mode)
            {
                case Weapon.Mode.Auto:
                    if (_mouseState.LeftButton == ButtonState.Pressed || _gamePadState.IsButtonDown(Controls.ButtonShoot))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case Weapon.Mode.Single:
                    if (WasMouseLeftButtonPressed() || WasButtonPressed(Controls.ButtonShoot))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            } 

        }
    }
}
