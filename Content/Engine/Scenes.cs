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

        public static void LoadSceneID(string ID)
        {
            var scene = Scenes[ID];
            if (scene != null)
            {
                if (!LoadedScenes.Contains(scene))
                {
                    LoadedScenes.Add(scene);
                }
            }
        }
        public static void DisableSceneID(string ID)
        {
            var scene = Scenes[ID];
            if (scene != null)
            {
                if (LoadedScenes.Contains(scene))
                {
                    LoadedScenes.Remove(scene);
                }
            }
        }
        public static void DiscardSceneID(string ID)
        {
            var scene = Scenes[ID];
            if (scene != null)
            {
                Scenes.Remove(ID);
                if (LoadedScenes.Contains(scene))
                {
                    LoadedScenes.Remove(scene);
                }
            }
        }
        public static void LoadScene(Scene scene)
        {
            if (!LoadedScenes.Contains(scene))
            {
                LoadedScenes.Add(scene);
            }
        }
        public static void DisableScene(Scene scene)
        {
            if (LoadedScenes.Contains(scene))
            {
                LoadedScenes.Remove(scene);
            }
        }
        public static void DiscardScene(Scene scene)
        {
            Scenes.Remove(scene.sceneID);
            if (LoadedScenes.Contains(scene))
            {
                LoadedScenes.Remove(scene);
            }
        }

        public class Scene
        {
            public map = null;
            public string sceneID;
            public Scene(string ID)
            {
                Scenes.Add(ID, this);
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
                public List<Solid2D> solid2D = new();
            }
            public void Update()
            {

            }
            public void Draw()
            {
            }
        }
        public class Scene3D : Scene
        {
            public Scene3D(string ID) : base(ID) { }
            public Objects objects = new Objects();
            public class Objects
            {
                public List<Generic3D> generic3D = new(); // entity without 3D physics
                public List<Solid3D> solid3D = new();
            }
        }
    }
}