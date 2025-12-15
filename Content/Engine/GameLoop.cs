using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

            foreach (var scene in Scenes.Values)
            {
                if (scene is Scene2D s2d)
                {
                    foreach (var obj in s2d.objects.generic2D.ToArray())
                    {
                        obj.InternalUpdate();
                    }
                }
            }

        }

        public static void Draw()
        {
            HoneycombCore._spriteBatch.Begin();
            foreach (var scene in Scenes.Values)
            {
                if (scene is Scene2D s2d)
                {
                    foreach (var obj in s2d.objects.generic2D.ToArray())
                    {
                        obj.InternalDraw();
                    }
                }
            }
            HoneycombCore._spriteBatch.End();
        }
    }
}