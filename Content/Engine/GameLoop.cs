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
        public static float deltaTime;

        public static void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * 60;

            foreach (var i in Objects.generic2D.ToArray())
            {
                i.InternalUpdate();
            }
        }

        public static void Draw()
        {
            HoneycombCore._spriteBatch.Begin();
            foreach (var i in Objects.generic2D.ToArray())
            {
                i.InternalDraw();
            }
            HoneycombCore._spriteBatch.End();
        }
    }
}