using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HoneycombEngine
{
    public partial class Honeycomb
    {
        public static void SetFramerate(int fps)
        {
            HoneycombCore.Self.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / fps);
        }

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

            }
        }
    }
}