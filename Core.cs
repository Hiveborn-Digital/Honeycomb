using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Manuka;

namespace Honeycomb
{
    public class HoneycombCore : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static HoneycombCore Self;

        public HoneycombCore()
        {
            Self = this;
            _graphics = new GraphicsDeviceManager(this);
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0);

            var logStream = new FileStream("log.txt", FileMode.Append, FileAccess.Write);
            var logWriter = new StreamWriter(logStream) { AutoFlush = true };
            Console.SetOut(logWriter);
            Console.SetError(logWriter);
        }

        protected override void Initialize()
        {
            new Engine();
            Console.WriteLine($"[ENGINE] Initialised.");
            Renderer.GraphicsContext.Initialise(GraphicsDevice);
            Console.WriteLine($"[RENDERER] Initialised.");

            _spriteBatch = new SpriteBatch(Renderer.GraphicsContext.Device);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Engine.Loader.LoadContent.DoYourThing();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Engine.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Renderer.GraphicsContext.Device.Clear(Renderer.clearColour);

            Engine.Draw();

            base.Draw(gameTime);
        }
    }
}
