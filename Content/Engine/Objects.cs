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
        public class Objects
        {
            public static List<Generic> generic = new();
        }

        public class Generic
        {
            public Vector2 Position;
            public Generic()
            {
                Objects.generic.Add(this);
            }
            internal void InternalUpdate()
            {
                Update();
            }
            internal void InternalDraw()
            {
                Draw();
            }
            protected virtual void Update() { }
            protected virtual void Draw() { }
        }
    }
}