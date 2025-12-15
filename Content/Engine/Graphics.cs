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
        public static class GraphicsContext
        {
            public static GraphicsDevice Device { get; private set; }

            public static void Initialise(GraphicsDevice device)
            {
                Device = device;
            }
        }
    }
}