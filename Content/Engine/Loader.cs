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