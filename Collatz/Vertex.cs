using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    internal class Vertex
    {
        public int Value { get; set; }
        private Vertex? _upEdge1;
        private Vertex? _upEdge2;
        private Vertex? _downEdge;

        public Vertex(int value) => Value = value;


    }
}
