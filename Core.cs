using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace HoneycombEngine
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
            new Honeycomb();
            Honeycomb.GraphicsContext.Initialise(GraphicsDevice);

            _spriteBatch = new SpriteBatch(Honeycomb.GraphicsContext.Device);

            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Honeycomb.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Honeycomb.GraphicsContext.Device.Clear(Honeycomb.clearColour);

            Honeycomb.Draw();

            base.Draw(gameTime);
        }
    }
}
