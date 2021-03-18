﻿using SimpleCalculator.Extension;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SimpleCalculator
{
    public class ExtensibilityProvider
    {
        [Import(typeof(ICalculator))]
        public ICalculator Calculator;

        public ExtensibilityProvider()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory + "\\Extensions"));

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
