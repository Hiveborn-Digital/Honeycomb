using Microsoft.Xna.Framework;
using System.Text.Json.Serialization;

namespace Honeycomb
{
    public partial class Engine
    {
        public class Generic2D
        {
            public Vector2 Position;
            public Vector2 Speed;

            [JsonIgnore]
            public Engine.Scene scene;

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
            protected virtual void Update() { }
            protected virtual void Draw() { }
        }
        public class Solid2D : Generic2D
        {
            public Solid2D(string sceneID) : base(sceneID) { }
        }

        public class Generic3D
        {
            public Vector3 Position;
            public Vector3 Speed;

            [JsonIgnore]
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
        }
        public class Solid3D : Generic3D
        {
            public Solid3D(string sceneID) : base(sceneID) { }
        }
    }
}