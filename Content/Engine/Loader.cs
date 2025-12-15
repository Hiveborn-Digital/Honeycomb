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
        public static class Loader // unfinished
        {
            public static Assembly LoadDLL(string path)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(path); // reading the raw bytes keeps the file unlocked so ur OS doesn't shit its pants when you try to modify it
                    return Assembly.Load(data);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}