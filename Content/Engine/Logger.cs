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
        public class Log
        {
            public static void Info(string log){
                Console.WriteLine($"[INFO] {log}");
            }

            public static void Warn(string log){
                Console.WriteLine($"[WARN] {log}");
            }

            public static void Err(string log){
                Console.Error.WriteLine(new InvalidOperationException($"[ERR] {log}"));

            }
        }
    }
}