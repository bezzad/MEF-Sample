using SimpleCalculator.Extension;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SimpleCalculator
{
    public class ExtensibilityProvider
    {
        [Import(typeof(ICalculator))] 
        private ICalculator _calculator; // Note: only field supported
        // ReSharper disable once ConvertToAutoProperty
        public ICalculator Calculator => _calculator;

        public ExtensibilityProvider(string extensionsPath)
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(GetType().Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(extensionsPath));

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
