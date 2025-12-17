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
        public Honeycomb()
        {
            new Honeycomb.Scene2D("Game2D");
            Console.WriteLine("Honeycomb Engine Initialised");
        }
    }
}