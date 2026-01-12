using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Honeycomb
{
    public static class PackageManager
    {
        public static List<VPackage> Packages = new();

        public static void LoadPackagesFromAssembly(Assembly bin)
        {
            var types = bin.GetTypes().Where(type => typeof(VPackage).IsAssignableFrom(type) && !type.IsAbstract);

            foreach (var type in types)
            {
                var package = (VPackage)Activator.CreateInstance(type)!;
                Packages.Add(package);
                package.OnReady();
            }
        }
    }

    public abstract class VPackage
    {
        public abstract void OnReady();
    }
}
