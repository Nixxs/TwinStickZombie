using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace TwinStickZombie
{
    public class Animation
    {
        private List<Texture2D> _frames = new List<Texture2D>();
        private int _frameUpdateSpeed;
        private int _frameUpdateTimer = 0;
        private int _frameIndex = 0;
        public Texture2D CurrentFrame;
        private Mode _mode;
        public bool PlaySingle { get; private set; }


        public Animation(List<Texture2D> frames, int frameUpdateSpeed, Mode mode)
        {
            _frames = frames;
            _frameUpdateSpeed = frameUpdateSpeed;
            CurrentFrame = _frames[_frameIndex];
            _mode = mode;
            PlaySingle = false;
        }

        public enum Mode
        {
            Looping,
            OnDemand
        }

        private void UpdateFrame()
        {
            if (_frameUpdateTimer <= 0)
            {
                // reset the timer
                _frameUpdateTimer = _frameUpdateSpeed;
                CurrentFrame = _frames[_frameIndex];
                _frameIndex += 1;

                // if the frame index goes beryond the size of the frames
                // then reset it back to zero. This is for the continuously 
                // looping animations ones only
                if (_frameIndex > _frames.Count - 1)
                {
                    _frameIndex = 0;

                    // if playsingle was set to true then it is now set to false
                    // will will stop this animation from playing again until it
                    // is again set to true.
                    PlaySingle = false;
                }
            }
            else
            {
                // i frame has passed, subtract from the timer
                _frameUpdateTimer -= 1;
            }
        }

        public void Update()
        {
            if (_mode == Mode.Looping)
            {
                UpdateFrame();
            }
            else
            {
                // this is where I will somehow handle the play only once code
                if (PlaySingle)
                {
                    UpdateFrame();
                }
                else
                {
                    CurrentFrame = _frames[0];
                }
            }
        }

        public void Play()
        {
            PlaySingle = true;
        }
    }
}
