using Collatz.Services;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Collatz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Collatz Analyzer");
            //var processor = new CollatzProcessor();
            long x = 9;
            var collatzOfX = CollatzProcessor.ComputeStatic(x);
            CollatzProcessor.ConsoleDisplayForList(collatzOfX);
        }
    }
}