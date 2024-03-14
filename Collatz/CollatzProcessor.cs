using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Services
{
    public class CollatzProcessor
    {
        public DirectedGraph CollatzGraph { get; internal set; }
        
        public CollatzProcessor(int maxN)
        {
            CollatzGraph = new DirectedGraph(maxN);
            // TODO: * init: hydrate graph incl. checking data folder for serialized (packed) graph & metadata (steps, max, etc.)
            // TODO: Add delegate methods to do the calculations (one for odd, one for even) with parametrization or static compilation?
            
        }

        public DirectedGraph AscendGraph()
        {
            CollatzGraph.Ascend();
            return CollatzGraph;
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
        public static RunResult ComputeStatic(int initialValue)
        {
            if (initialValue <= 1) return new RunResult(1);

            var result = new RunResult(initialValue);
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

        public static void GenerateGraphLayoutForStatic(RunResult result)
        {

        }
    }
}
