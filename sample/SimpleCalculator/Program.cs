using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using SimpleCalculator.Extension;

namespace SimpleCalculator
{
    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;


        private Program()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory + "\\Extensions"));


            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }


        static void Main(string[] args)
        {
            var p = new Program(); //Composition is performed in the constructor
            Console.WriteLine("Enter Command:");
            while (true)
            {
                var s = Console.ReadLine();
                Console.WriteLine(p.calculator.Calculate(s));
            }
            

        }
    }
}
