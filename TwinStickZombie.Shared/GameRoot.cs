using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TwinStickZombie
{
    public class GameRoot : Game
    {
        GraphicsDeviceManager graphics;
        RenderTarget2D renderTarget;
        float renderScale = 0.4444f;

        SpriteBatch spriteBatch;
        SpriteFont debugText;

        public static GameRoot Instance { get; private set; }
        public static Viewport Viewport
        {
            get
            {
                return Instance.GraphicsDevice.Viewport;
            }
        }
        public static Vector2 ScreenSize
        {
            get
            {
                return new Vector2(Viewport.Width, Viewport.Height);
            }
        }

        public GameRoot()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            //must have base.Initialize() run first before anything else
            base.Initialize();
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            EntityManager.Add(Player.Instance);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Create the render target for drawing the game to and allowing us to scale later.
            renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);

            Art.Load(Instance);

            debugText = Content.Load<SpriteFont>("font\\debug");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            EntityManager.Update();
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // change this scale to configure how much the camera is zoomed in
            renderScale = 1.5f;

            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            EntityManager.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            spriteBatch.DrawString(debugText, 
                                    String.Format("X: {0}\nY: {1}\n", 
                                                  Player.Instance.Position.X, 
                                                  Player.Instance.Position.Y), 
                                    new Vector2(10f, 10f), 
                                    Color.White);
            // this moves the camera around, at the moment the centre of the camera and its position is on the player so the player is pretty
            // much in the middle of the screen all the time.
            spriteBatch.Draw(renderTarget, Player.Instance.Position, null, Color.White, 0f, Player.Instance.Position, renderScale, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
