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
            public static List<Generic2D> generic2D = new();
            public static List<Generic3D> generic3D = new();
        }

        public class Generic2D
        {
            public Vector2 Position;
            public Vector2 Speed;
            public int Depth;
            public Generic2D()
            {
                Objects.generic2D.Add(this);
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

        public class Generic3D
        {
            public Vector3 Position;
            public Vector3 Speed;
            public Generic3D()
            {
                Objects.generic3D.Add(this);
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