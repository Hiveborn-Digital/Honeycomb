using System;

namespace HoneycombInit
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Honeycomb.HoneycombCore();
        }
    }
}