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

            Console.WriteLine("___________________");
            Console.WriteLine("");
            Console.WriteLine("Started New Session");
            Console.WriteLine("___________________");
            Console.WriteLine("");
        }

        protected override void Initialize()
        {
            new Engine();
            Console.WriteLine($"[ENGINE]     {DateTime.Now.ToString()} - Initialised.");
            Renderer.GraphicsContext.Initialise(GraphicsDevice);
            new Renderer();
            Console.WriteLine($"[RENDERER]   {DateTime.Now.ToString()} - Initialised.");

            _spriteBatch = new SpriteBatch(Renderer.GraphicsContext.Device);

            Engine.Loader.LoadContent.DoYourThing();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
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
