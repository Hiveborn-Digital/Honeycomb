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
        public Engine()
        {
            new Scene2D("Game2D");
            Console.WriteLine("Honeycomb Engine Initialised");
        }
    }
}