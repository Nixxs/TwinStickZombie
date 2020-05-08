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
        private bool _isLooping;
        public Texture2D CurrentFrame;


        public Animation(List<Texture2D> frames, int frameUpdateSpeed, bool isLooping)
        {
            _frames = frames;
            _frameUpdateSpeed = frameUpdateSpeed;
            CurrentFrame = _frames[_frameIndex];
            _isLooping = isLooping;
        }

        public void Update()
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
                }
            } else
            {
                // i frame has passed, subtract from the timer
                _frameUpdateTimer -= 1;
            }
        }
    }
}
