using System;
using System.Collections.Generic;

namespace Honeycomb
{
    public partial class Engine
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

        public abstract class Scene
        {
            public Map map = null;
            public string sceneID;

            protected Scene() { }

            protected Scene(string ID)
            {
                Scenes.Add(ID, this);
                sceneID = ID;
            }
            public int Depth;

            public Scene Clone(string ID)
            {
                var clone = (Scene)MemberwiseClone();

                clone.CloneObjects();
                Scenes.Add(ID, this);
                clone.sceneID = ID;

                return clone;
            }
            public void ChangeSceneID(string ID)
            {
                Scenes.Remove(sceneID);
                sceneID = ID;
                Scenes.Add(ID, this);
            }
            protected abstract void CloneObjects();
        }
        public class Scene2D : Scene
        {
            public Scene2D() { }
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

            protected override void CloneObjects()
            {
                var newObjects = new Objects();

                foreach (var obj in objects.generic2D)
                {
                    var objClone = obj.Clone();
                    objClone.scene = this;
                    newObjects.generic2D.Add(objClone);
                }

                foreach (var obj in objects.solid2D)
                {
                    var objClone = obj.Clone();
                    objClone.scene = this;
                    newObjects.solid2D.Add(objClone);
                }

                objects = newObjects;
            }


        }
        public class Scene3D : Scene
        {
            public Scene3D() { }
            public Scene3D(string ID) : base(ID) { }
            public Objects objects = new Objects();
            public class Objects
            {
                public List<Generic3D> generic3D = new(); // entity without 3D physics
                public List<Solid3D> solid3D = new();
            }
            public void Update()
            {
            }
            public void Draw()
            {
            }

            protected override void CloneObjects()
            {
                var newObjects = new Objects();

                foreach (var obj in objects.generic3D)
                {
                    var objClone = obj.Clone();
                    objClone.scene = this;
                    newObjects.generic3D.Add(objClone);
                }

                foreach (var obj in objects.solid3D)
                {
                    var objClone = obj.Clone();
                    objClone.scene = this;
                    newObjects.solid3D.Add(objClone);
                }

                objects = newObjects;
            }
        }
    }
}