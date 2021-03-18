using System;

namespace SimpleCalculator
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Composition is performed in the constructor
            var provider = new ExtensibilityProvider(Environment.CurrentDirectory + "\\Extensions"); 
            Console.WriteLine("Enter Command:");
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(provider.Calculator?.Calculate(input));
            }
        }
    }
}
