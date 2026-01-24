using Microsoft.Xna.Framework;
using System.Text.Json.Serialization;

namespace Honeycomb
{
    public partial class Engine
    {
        public class Collider2D
        {
            public Vector2 Scale;
            public Collider2D(Vector2 relative_position, Vector2 scale)
            {
                
            }
        }
        public class Generic2D
        {
            public Vector2 Position;
            public Vector2 Speed;

            public Scene scene;

            public int Depth;
            public Generic2D() { }
            public Generic2D(string sceneID)
            {
                scene = Scenes[sceneID];
                if (Scenes[sceneID] is Scene2D s2d)
                {
                    switch (this) // pls make sure Generic2D stays at the bottom
                    {
                        case Solid2D g2d:
                            s2d.objects.solid2D.Add(g2d);
                            break;

                        case Generic2D g2d:
                            s2d.objects.generic2D.Add(g2d);
                            break;
                    }
                }
            }
            internal void InternalUpdate()
            {
                Update();
            }
            internal void InternalDraw()
            {
                Draw();
            }
            public virtual Generic2D Clone()
            {
                var clone = (Generic2D)this.MemberwiseClone();
                return clone;
            }
            protected virtual void Update() { }
            protected virtual void Draw() { }

        }
        public class Solid2D : Generic2D
        {
            public Solid2D(string sceneID) : base(sceneID) { }

            public override Solid2D Clone()
            {
                var clone = (Solid2D)this.MemberwiseClone();
                return clone;
            }
        }

        public class Generic3D
        {
            public Vector3 Position;
            public Vector3 Speed;

            public Scene scene;

            public int Depth;
            public Generic3D() { }
            public Generic3D(string sceneID)
            {
                scene = Scenes[sceneID];
                if (Scenes[sceneID] is Scene3D s3d)
                {
                    switch (this) // keep Generic3D at the bottom too
                    {
                        case Solid3D g3d:
                            s3d.objects.solid3D.Add(g3d);
                            break;

                        case Generic3D g3d:
                            s3d.objects.generic3D.Add(g3d);
                            break;
                    }
                }
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

            public virtual Generic3D Clone()
            {
                var clone = (Generic3D)this.MemberwiseClone();
                return clone;
            }
        }
        public class Solid3D : Generic3D
        {
            public Solid3D(string sceneID) : base(sceneID) { }

            public override Solid3D Clone()
            {
                var clone = (Solid3D)this.MemberwiseClone();
                return clone;
            }
        }
    }
}