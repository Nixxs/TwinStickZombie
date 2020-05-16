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

        SpriteBatch spriteBatch;
        SpriteFont debugFont;
        String debugText;

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
            EntityManager.Add(Enemy.Zombie.Create(new Vector2(500, 500)));
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Creating a render target allows for static screen items to be draw on top
            // of the game screen
            renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);

            Art.Load(Instance);

            debugFont = Content.Load<SpriteFont>("font\\debug");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            EntityManager.Update();
            Input.Update();
            Camera.Update();

            // DEBUG START
            // run the update method for the debug and testing code
            Debug.Update();
            // DEBUG END

            debugText = String.Format("X: {0}\nY: {1}\n AimDir: {2}, WeaponPos: {3}",
                        Player.Instance.Position.X,
                        Player.Instance.Position.Y,
                        Input.GetAimDirection(),
                        Player.Instance.PrimaryWeapon.Position);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.DarkGray);
            
            // draw the game screen to the render target
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: Camera.Transform);
            EntityManager.Draw(spriteBatch);
            spriteBatch.Draw(Art.ZombieIdle1, new Vector2(300, 300), Color.White);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);

            // draw render target to the screen
            spriteBatch.Begin(SpriteSortMode.Texture);
            
            spriteBatch.DrawString(debugFont, debugText,  new Vector2(10f, 10f), Color.Black);
            spriteBatch.Draw(renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
