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
        public static class Loader
        {
            public static Assembly LoadDLL(string path)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(path);
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