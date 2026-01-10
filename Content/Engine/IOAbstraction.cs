using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
                    items = Directory.GetFiles(folderpath);
                }
                return new List<string>(items);
            }
        }
    }
}