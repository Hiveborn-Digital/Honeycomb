using System;

namespace Honeycomb
{
    public partial class Engine
    {
        public class Log
        {
            public static void Info(string log){
                Console.WriteLine($"[INFO]       {DateTime.Now.ToString()} - {log}");
            }

            public static void Warn(string log){
                Console.WriteLine($"[WARN]       {DateTime.Now.ToString()} - {log}");
            }

            public static void Err(string log){
                Console.Error.WriteLine(new InvalidOperationException($"[ERR]        {DateTime.Now.ToString()} - {log}"));

            }
        }
    }
}