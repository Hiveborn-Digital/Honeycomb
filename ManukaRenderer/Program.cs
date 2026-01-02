using System;

namespace ManukaRendererInit
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new ManukaRendererCore.ManukaCore();
        }
    }
}