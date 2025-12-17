using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

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


        [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
        [JsonDerivedType(typeof(Scene2D), "2D")]
        [JsonDerivedType(typeof(Scene3D), "3D")]
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

            public string GetImage()
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                };
                return JsonSerializer.Serialize<Scene>(this, options);
            }
            public Scene GetImageAsScene()
            {
                string image = GetImage();
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                return JsonSerializer.Deserialize<Scene>(image, options);
            }
            public void LoadImage(Scene image)
            {
                bool loaded = LoadedScenes.Contains(this);
                DiscardScene(this);

                Scenes.Add(image.sceneID, image);

                Console.WriteLine(Scenes[image.sceneID].GetImage());

                LoadScene(image);

                if (image is Scene2D s2d)
                {
                    foreach (var obj in s2d.objects.generic2D)
                        obj.scene = image;
                    foreach (var obj in s2d.objects.solid2D)
                        obj.scene = image;
                }
                else if (image is Scene3D s3d)
                {
                    foreach (var obj in s3d.objects.generic3D)
                        obj.scene = image;
                    foreach (var obj in s3d.objects.solid3D)
                        obj.scene = image;
                }
            }
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
        }
    }
}