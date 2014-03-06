﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Hextasy.CardWarsTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog =
                new AggregateCatalog(
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new DirectoryCatalog("."));

            var compositionContainer = new CompositionContainer(catalog);
            var perf = compositionContainer.GetExportedValue<DeepCopyPerformanceTester>().Start();
            Console.WriteLine(perf.ToString());
        }
    }
}
