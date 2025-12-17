using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace HoneycombEngine
{
    public partial class Honeycomb
    {
        public static Color clearColour = Color.Black;

        public static class GraphicsContext
        {
            public static GraphicsDevice Device { get; private set; }

            public static void Initialise(GraphicsDevice device)
            {
                Device = device;
            }
        }

        public static class Draw2D
        {
            public static void DrawRect(Vector2 Position, Vector2 Dimensions, Color colour)
            {
                // remind me to do this later lol
            }
        }
        public class Window
        {
            public static void SetFramerate(int fps)
            {
                HoneycombCore.Self.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / fps);
            }
            public static void VSync(bool enabled)
            {
                HoneycombCore._graphics.SynchronizeWithVerticalRetrace = enabled;
                HoneycombCore._graphics.ApplyChanges();
            }
            public static void ChangeScale(Vector2 windowScale)
            {
                HoneycombCore._graphics.PreferredBackBufferWidth = (int)Math.Floor(windowScale.X);
                HoneycombCore._graphics.PreferredBackBufferHeight = (int)Math.Floor(windowScale.Y);
                HoneycombCore._graphics.ApplyChanges();
            }
        }
    }
}