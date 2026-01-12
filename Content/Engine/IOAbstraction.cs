using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Honeycomb
{
    public partial class Engine
    {
        public class IO
        {
            public static List<string> GetFolderContents(string folderpath, bool subfolders = false)
            {
                string[] items;
                if (subfolders)
                {
                    items = Directory.GetFileSystemEntries(folderpath, "*", SearchOption.AllDirectories);
                } else
                {
                    items = Directory.GetFileSystemEntries(folderpath);
                }
                return new List<string>(items);
            }
            public static void SaveWindowPreferences()
            {
                var prefs = new WindowPreferences
                {
                    Fullscreen = HoneycombCore._graphics.IsFullScreen,
                    Borderless = HoneycombCore.Self.Window.IsBorderless,
                    DimensionX = HoneycombCore._graphics.PreferredBackBufferWidth,
                    DimensionY = HoneycombCore._graphics.PreferredBackBufferHeight,
                    CursorVisible = HoneycombCore.Self.IsMouseVisible,
                    VSync = HoneycombCore._graphics.SynchronizeWithVerticalRetrace,
                    FPS = (int)(1 / HoneycombCore.Self.TargetElapsedTime.TotalSeconds)
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(prefs, options);

                string path = "Honeycomb/conf/windowState.json";
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                File.WriteAllText(path, json);
            }
            public class WindowPreferences
            {
                public bool Fullscreen { get; set; }
                public bool Borderless { get; set; }
                public int DimensionX { get; set; }
                public int DimensionY { get; set; }
                public bool CursorVisible { get; set; }
                public bool VSync { get; set; }
                public int FPS { get; set; }
            }

        }
    }
}