using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    public class Vertex
    {
        public int Value { get; set; }

        /// <summary>
        /// The edge (if it exists) for which the attached vertex's value is odd
        /// </summary>
        /// <remarks>
        /// Up is away from 1 ("The enemy's gate is down")<br/>
        /// Ex: The odd up-edge of 16 is 5
        /// </remarks>
        public int UpEdgeOdd; // up is away from 1

        /// <summary>
        /// The edge (if it exists) for which the attached vertex's value is even
        /// </summary>
        /// <remarks>
        /// Up is away from 1 ("The enemy's gate is down")<br/>
        /// Ex: The even up-edge of 16 is 32
        /// </remarks>
        public int UpEdgeEven;

        /// <summary>
        /// The edge which leads to 1
        /// </summary>
        /// <remarks>
        /// Down is toward 1 ("The enemy's gate is down")<br/>
        /// Ex: The down edge of 16 is 8
        /// </remarks>
        public int DownEdge;

        /// <summary>
        /// Construct an unconnected Vertex
        /// </summary>
        /// <param name="value">The vertex value</param>
        public Vertex(int value)
        {
            Value = value;
        }
    }
}
