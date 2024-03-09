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
        public static List<long> ComputeStatic(long initialValue)
        {
            if (initialValue <= 1) return new List<long> { 1 };
            var current = initialValue;
            var values = new List<long> { current };
            while (current != 1)
            {
                current = (current % 2 == 0) ? 
                    current / 2 : 
                    3 * current + 1;
                values.Add(current);
            }
            return values;
        }

        public static void ConsoleDisplayForList(List<long> collatzOfX)
        {
            var initial = collatzOfX.First();
            var remainder = collatzOfX.Skip(1).ToList();
            var max = collatzOfX.Max();
            Console.WriteLine($"Collatz of {initial} with length {remainder.Count} and max {max}:");
            Console.Write(initial);
            remainder.ForEach(x => Console.Write($"\t{x}"));
            Console.WriteLine();
        }
    }
}
