using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Honeycomb
{
    public partial class Engine
    {
        public static float deltaTime;
        public static float runTime = 0;
        public static float gameSpeed = 1;

        public static void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * 60 * gameSpeed;
            runTime += deltaTime;

            Input.Update();

            foreach (var scene in LoadedScenes.ToArray())
            {
                if (scene is Scene2D s2d)
                {
                    foreach (var obj in s2d.objects.generic2D.ToArray())
                    {
                        obj.InternalUpdate();
                    }
                }
                if (scene is Scene3D s3d)
                {
                    foreach (var obj in s3d.objects.generic3D.ToArray())
                    {
                        obj.InternalUpdate();
                    }
                }
            }
        }

        public static void Draw()
        {
            foreach (var scene in LoadedScenes.ToArray())
            {
                HoneycombCore._spriteBatch.Begin();
                if (scene is Scene2D s2d)
                {
                    foreach (var obj in s2d.objects.generic2D.ToArray())
                    {
                        obj.InternalDraw();
                    }
                }
                if (scene is Scene3D s3d)
                {
                    foreach (var obj in s3d.objects.generic3D.ToArray())
                    {
                        obj.InternalDraw();
                    }
                }
                HoneycombCore._spriteBatch.End();
            }
        }
    }
}