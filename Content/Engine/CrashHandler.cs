using System;
using System.Diagnostics;
using System.IO;

namespace Honeycomb
{
    public partial class Engine
    {
        public class Crash
        {
            public static void Panic(string reason)
            {
                Console.Error.WriteLine(new InvalidOperationException($"[PANIC] {reason}"));

                Process.Start(new ProcessStartInfo
                {
                    FileName = "log.txt",
                    UseShellExecute = true
                });
                Environment.FailFast(reason);
            }
            public static void Soft(string reason)
            {
                
            }
        }
    }
}