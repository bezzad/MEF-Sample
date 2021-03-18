using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new ExtensibilityProvider(); //Composition is performed in the constructor
            Console.WriteLine("Enter Command:");
            while (true)
            {
                var s = Console.ReadLine();
                Console.WriteLine(provider.Calculator.Calculate(s));
            }
        }
    }
}
