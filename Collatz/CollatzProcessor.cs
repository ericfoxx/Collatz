using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Services
{
    public class CollatzProcessor
    {
        public CollatzProcessor()
        {
            /* TODO:
            * init: hydrate graph incl. checking data folder for serialized (packed) graph & metadata (steps, max, etc.)
            */

        }
        
        /* TODO:
         * unpack graph
         * pack graph
         * auto-search: visual display as it crunches _n_
         */

        /// <summary>
        /// Computes the Collatz sequence for a single input
        /// </summary>
        /// <param name="initialValue">The initial value</param>
        /// <returns>A list of the values generated via iterating the sequence</returns>
        public static RunResult ComputeStatic(long initialValue)
        {
            var result = new RunResult(initialValue);
            if (initialValue <= 1) return result;
            var current = initialValue;
            while (current != 1)
            {
                current = (current % 2 == 0) ? 
                    current / 2 : 
                    3 * current + 1;
                result.Values.Add(current);
            }
            result.Analyze();
            return result;
        }

        public static void ConsoleDisplayForResult(RunResult result)
        {
            Console.WriteLine($"Collatz of {result.InitialValue} with {result.Steps} steps and max {result.Max}:");
            Console.Write(result.InitialValue);
            result.Values.Skip(1).ToList().ForEach(x => Console.Write($"\t{x}"));
            Console.WriteLine();
        }
    }
}
