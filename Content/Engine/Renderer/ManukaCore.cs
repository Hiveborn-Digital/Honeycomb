using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using Honeycomb;
using System.Globalization;

namespace Manuka
{
    public partial class Renderer
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
        public class Window
        {
            public static Vector2 getScale = new Vector2(HoneycombCore._graphics.PreferredBackBufferWidth, HoneycombCore._graphics.PreferredBackBufferHeight);
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
                getScale = new Vector2((int)Math.Floor(windowScale.X), (int)Math.Floor(windowScale.Y));
                HoneycombCore._graphics.PreferredBackBufferWidth = getScale.X;
                HoneycombCore._graphics.PreferredBackBufferHeight = getScale.Y;
                HoneycombCore._graphics.ApplyChanges();
            }
            public static void SetCursorVisibility(bool enabled)
            {
                HoneycombCore.Self.IsMouseVisible = enabled;
            }
            public static void SetFullscreen(bool enabled)
            {
                HoneycombCore._graphics.IsFullScreen = enabled;
                HoneycombCore._graphics.ApplyChanges();
            }
            public static void SetBorderless(bool enabled)
            {
                HoneycombCore.Self.Window.IsBorderless = enabled;
                HoneycombCore._graphics.ApplyChanges();
            }
            public static void UserScaling(bool enabled)
            {
                HoneycombCore.Self.Window.AllowUserResizing = enabled;
                HoneycombCore._graphics.ApplyChanges();
            }
        }
        public static Color HexToColour(string hex)
        {
            string clean = hex.Replace("#", "");
            int col = Int32.Parse(clean, NumberStyles.HexNumber);

            int r = 0;
            int g = 0;
            int b = 0;
            int a = 255;

            switch (clean.Length)
            {
                case 3:
                    r = ((col >> 8) & 0xF) * 17;
                    g = ((col >> 4) & 0xF) * 17;
                    b = (col & 0xF) * 17;
                    a = 255;
                    break;

                case 4:
                    r = ((col >> 12) & 0xF) * 17;
                    g = ((col >> 8) & 0xF) * 17;
                    b = ((col >> 4) & 0xF) * 17;
                    a = (col & 0xF) * 17;
                    break;

                case 6:
                    r = (col >> 16) & 0xFF;
                    g = (col >> 8) & 0xFF;
                    b = col & 0xFF;
                    a = 255;
                    break;

                case 8:
                    r = (col >> 24) & 0xFF;
                    g = (col >> 16) & 0xFF;
                    b = (col >> 8) & 0xFF;
                    a = col & 0xFF;
                    break;
            }
            return new Color(r, g, b, a);
        }
    }
}