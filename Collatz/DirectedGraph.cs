using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    public class DirectedGraph
    {
        /// <summary>
        /// A dictionary of the graph's vertices, using their Values as keys
        /// </summary>
        public Dictionary<int, Vertex> Vertices { get; internal set; }

        /// <summary>
        /// The maximum value of the most extreme vertex
        /// </summary>
        public int MaxN { get; internal set; }

        /// <summary>
        /// The value of the vertex currently being processed
        /// </summary>
        public int CurrentN { get; set; }

        /// <summary>
        /// The values which have currently been discovered in a descent
        /// </summary>
        /// <remarks>
        /// Do not use if ascending from 1
        /// </remarks>
        //public List<int> DiscoveredValuesInDescent { get; set; }

        /// <summary>
        /// The values which are currently connected to the root graph in an ascent
        /// </summary>
        public List<int> ConnectedValuesInAscent { get; set; }

        /// <summary>
        /// OEIS006577 - # of steps to reach 1 from value at current index
        /// </summary>
        /// <example>
        /// StepsForI[9] = 19
        /// </example>
        public List<int> StepsForI { get; set; }

        /// <summary>
        /// OEIS025586 - max value reached for starting value at current index
        /// </summary>
        /// <example>
        /// MaxForI[9] = 52
        /// </example>
        public List<int> MaxForI { get; set; }

        /// <summary>
        /// A working list containing generated graphs which do not yet connect with the graph which leads to 1
        /// </summary>
        //public List<DirectedGraph> DisconnectedGraphs { get; set; }

        /// <summary>
        /// A directed graph with root 1, able to contain all values up to int.MaxValue (0x7fffffffffffffffL)
        /// </summary>
        public DirectedGraph() {
            Vertices = new Dictionary<int, Vertex>(int.MaxValue);
            MaxN = int.MaxValue;
            CurrentN = 1;
            //DiscoveredValuesInDescent = new List<int>(int.MaxValue);
            ConnectedValuesInAscent= new List<int>(int.MaxValue);
            StepsForI = new List<int>(int.MaxValue);
            MaxForI = new List<int>(int.MaxValue);
            //DisconnectedGraphs = new List<DirectedGraph>();
        }

        /// <summary>
        /// A directed graph with root 1, able to contail all values up to a specified max
        /// </summary>
        /// <param name="maxN">The max value of any vertex in the graph</param>
        public DirectedGraph(int maxN)
        {
            Vertices = new Dictionary<int, Vertex>(maxN);
            Vertices.Add(1, new Vertex(1));
            MaxN = maxN;
            CurrentN = 1;
            ConnectedValuesInAscent= new List<int>(maxN);
            //DiscoveredValuesInDescent = new List<int>(max);
            StepsForI = new List<int>(maxN);
            MaxForI = new List<int>(maxN);
        }

        /// <summary>
        /// Following the Collatz algorithm, ascend's to this graph's MaxN
        /// </summary>
        /// <remarks>
        /// By convention, 1 only has an even Up Edge to avoid loop at 4
        /// </remarks>
        public void Ascend()
        {
            // These fix the logic issues that happen because 2 / 1 % 2 == 1
            if (MaxN == 1) return;
            AttachUpEvenTo(1, 2);
            AttachDownTo(2, 1);
            if (MaxN == 2) return;
            
            int target;
            // TODO: at certain interval, analyze the current nodes for Max & Steps
            for (int current = 3; current <= MaxN; current++)
            {
                if (!Vertices.ContainsKey(current)) // Unconnected node, ex: 3
                {
                    Vertices.Add(current, new Vertex(current));
                }

                // ONLY initiate Collatz calculations downwards (i.e., if odd, 3n+1, if even, n/2)
                // so 1 does NOTHING (skip the 4 connection), 2 only connects to 1 (& vice versa)
                // 3 hooks to 10 both ways (6 will connect to 3 when it appears)
                // SKIP 4 connecting to 1 (done above)

                if (current % 2 == 0)
                {
                    AttachDownTo(current, current / 2);
                    AttachUpEvenTo(current / 2, current);
                } else
                {
                    try
                    {
                        target = 3 * current + 1;
                        if (target > MaxN) continue;

                        AttachDownTo(current, target);
                        AttachUpOddTo(target, current);
                    }
                    catch (OverflowException)
                    {
                        // This would be bigger than int.Max, so skip this operation
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Attach source vertex along Up Odd edge to another
        /// </summary>
        /// <remarks>
        /// Remember, in the traditional Collatz sequence, the Up Odd edge will result in a smaller, odd integer<br/>
        /// Ex: <c>AttachUpOddTo(16,5);</c>
        /// </remarks>
        /// <exception cref="System.ArithmeticException">
        /// Thrown when attempting to attach vertex upward along the Up Odd edge to a non-odd vertex
        /// </exception>
        /// <param name="source">The value of the vertex to attach up from</param>
        /// <param name="dest">The value of the vertex to attach down to</param>
        public void AttachUpOddTo(int source, int dest)
        {
            if (dest % 2 == 0)
                throw new ArithmeticException($"Improper attempt to attach vertex with value {source} to non-odd vertex with value {dest}");
            Vertices[source].UpEdgeOdd = dest;
            if (!Vertices.ContainsKey(dest))
            {
                Vertices.Add(dest, new Vertex(dest));
            }
            Vertices[dest].DownEdge = source;
        }

        /// <summary>
        /// Attach source vertex along Up Even edge to another
        /// </summary>
        /// <remarks>
        /// Remember, in the traditional Collatz sequence, the Up Even edge will result in a larger, even integer<br/>
        /// Ex: <c>AttachUpEvenTo(16,32);</c>
        /// </remarks>
        /// <exception cref="System.ArithmeticException">
        /// Thrown when attempting to attach vertex upward along the Up Even edge to a non-even vertex
        /// </exception>
        /// <param name="source">The value of the vertex to attach up from</param>
        /// <param name="dest">The value of the vertex to attach down to</param>
        public void AttachUpEvenTo(int source, int dest)
        {
            if (dest % 2 == 1)
                throw new ArithmeticException($"Improper attempt to attach vertex with value {source} to non-even vertex with value {dest}");
            Vertices[source].UpEdgeEven = dest;
            if (!Vertices.ContainsKey(dest))
            {
                Vertices.Add(dest, new Vertex(dest));
            }
            Vertices[dest].DownEdge = source;
        }

        /// <summary>
        /// Attach source vertex to another along this vertex's Down edge (dest's up edge is not known)
        /// </summary>
        /// <remarks>
        /// In the traditional Collatz sequence, the Down edge always leads toward 1 but could result in a larger or smaller number<br/>
        /// Ex: <c>AttachDownTo( 16 , 8  );</c><br/>
        /// or: <c>AttachDownTo( 5  , 16 );</c>
        /// </remarks>
        /// <param name="source">The vertex to attach down from</param>
        /// <param name="dest">The vertex to attach to</param>
        public void AttachDownTo(int source, int dest)
        {
            Vertices[source].DownEdge = dest;
            if (!Vertices.ContainsKey(dest))
            {
                Vertices.Add(dest, new Vertex(dest));
            }
        }

        public static bool IsPowerOfTwo(int value)
        {
            return (value & (value - 1)) == 0;
        }
    }
}
