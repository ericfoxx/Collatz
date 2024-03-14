using Collatz.Utilities;
using Collatz.Services;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Collatz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Collatz Analyzer");
            Console.WriteLine("Choose a task:");
            Console.WriteLine("\t1. Compute & display to console a single Collatz sequence");
            Console.WriteLine("\t2. Compute & display to console a range of Collatz sequences");
            Console.WriteLine("\t3. Ascend the Collatz Directed Graph");
            Console.Write("Your choice [1|2|3]:\t");
            var choice = Console.ReadKey(true).ToString();

            int answer;

            Console.Write("You have chosen: ");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Compute & display to console a single Collatz sequence");
                    
                    ReadOption(prompt: "Choose a positive integer for which to compute a Collatz sequence", 
                        canBeEmpty: false, defaultValue: 1, out answer);
                    var collatzOfX = CollatzProcessor.ComputeStatic(answer);
                    Display.ConsoleSingleResult(collatzOfX);
                    break;

                case "2":
                    Console.WriteLine("Compute & display to console a range of Collatz sequences");
                    
                    ReadOption(prompt: "Choose a starting positive integer value: (default: 1)",
                        canBeEmpty: true, defaultValue: 1, out int startingValue);
                    ReadOption(prompt: "Choose an ending positive integer value",
                        canBeEmpty: false, defaultValue: 1, out int endingValue);
                    for (int i = startingValue; i <= endingValue; i++)
                    {
                        var collatzOfI = CollatzProcessor.ComputeStatic(i);
                        Display.ConsoleSingleResult(collatzOfI);
                    }
                    break;

                case "3":
                    Console.WriteLine("Ascend the Collatz Directed Graph");
                    ReadOption(prompt: "Choose an ending positive integer value (default: int.MaxValue)",
                        canBeEmpty: true, defaultValue: 1, out answer);
                    var processor = new CollatzProcessor(answer);
                    processor.AscendGraph();
                    // Output somehow

                    break;

                default:
                    throw new InvalidOperationException($"The value {choice} is not a valid choice. Exiting...");
            }
        }

        private static void ReadOption(string prompt, bool canBeEmpty, int defaultValue, out int choice)
        {
            Console.Write($"{prompt}:\t");
            var value = Console.ReadLine();
            bool valid;

            if (canBeEmpty && string.IsNullOrWhiteSpace(value))
            {
                choice = defaultValue;
                valid = true;
                return;
            }
            
            valid = int.TryParse(value, out choice);
            
            if (!valid || choice < 1)
            {
                throw new ArgumentOutOfRangeException($"The input '{value}' is not a positive integer. Exiting...");
            }
        }
    }
}