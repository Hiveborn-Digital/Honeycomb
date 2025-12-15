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
        public static Dictionary<string, Scene> Scenes = new();
        public static List<Scene> LoadedScenes = new();
        public static string currentSceneID = "Game2D";

        public class Scene
        {
            public string sceneID;
            public Scene(string ID)
            {
                Scenes.Add(ID, this);
                LoadedScenes.Add(this);
                sceneID = ID;
            }
            public int Depth;
            public void Delete()
            {
                Scenes.Remove(sceneID);
                LoadedScenes.Remove(this);
            }
        }
        public class Scene2D : Scene
        {
            public Scene2D(string ID) : base(ID) { }
            public Objects objects = new Objects();
            public class Objects
            {
                public List<Generic2D> generic2D = new(); // entity without 2D physics (like a decal)
            }
        }
        public class Scene3D : Scene
        {
            public Scene3D(string ID) : base(ID) { }
            public Objects objects = new Objects();
            public class Objects
            {
                public List<Generic3D> generic3D = new(); // entity without 3D physics
            }
        }
    }
}