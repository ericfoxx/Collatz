using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    internal class DirectedGraph
    {
        public Vertex Root { get; internal set; }
        
        public DirectedGraph() {
            Root = new Vertex(1);
        }

        
    }
}
