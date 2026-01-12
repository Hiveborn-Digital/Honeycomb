using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Honeycomb
{
    public partial class Engine
    {
        public static class Loader // unfinished
        {
            public static Assembly LoadDLL(string path)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(path); // reading the raw bytes keeps the file unlocked so ur OS doesn't shit its pants when you try to modify it
                    return Assembly.Load(data);
                }
                catch (Exception ex)
                {
                    Log.Warn($"Failed to load DLL from \"{path}\": {ex}");
                    return null;
                }
            }
            public static class LoadContent
            {
                private static bool loaded = false;

                public static void DoYourThing(){
                    if (!loaded)
                    {
                        v();
                        vdlc();
                        mdlc();
                        loaded = true;
                    }
                }
                private static void v() // Vanilla game content
                {
                    List<string> contents = IO.GetFolderContents(@"Content/v");
                    int packageCount = contents.Count;

                    Log.Info($"Loading {packageCount} packages in {Path.GetFullPath(@"Content/v")}");

                    int idx = 0;
                    foreach (var item in contents)
                    {
                        idx += 1;
                        if (Directory.Exists(item))
                        {
                            string config_file = Path.Combine(item, "_package.json");
                            if (File.Exists(config_file))
                            {
                                string data = File.ReadAllText(config_file);
                                using JsonDocument doc = JsonDocument.Parse(data);
                                JsonElement config = doc.RootElement;

                                Log.Info($"Loading vanilla package: {config.GetProperty("name").GetString()}, \"{item}\" ({idx} / {packageCount})");

                                LoadDLL(Path.Combine(item, config.GetProperty("DLL_path").GetString()));
                            }
                        } else
                        {
                            Log.Warn($"Not a package: \"{item}\" ({idx} / {packageCount})");
                        }
                    }
                }
                private static void vdlc() // Vanilla DLC content
                {
                    List<string> contents = IO.GetFolderContents(@"Content/vdlc");
                }
                private static void mdlc() // Community-made DLC content (like mods)
                {
                    List<string> contents = IO.GetFolderContents(@"Content/mdlc");
                }
            }
        }
    }
}