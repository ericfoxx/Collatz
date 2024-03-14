using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    public class RunResult
    {
        public int InitialValue { get; private set; }
        public int Steps { get; set; }
        public int Max { get; set; }
        public List<int> Values { get; set; }
        public RunResult(int initialValue) 
        { 
            InitialValue = initialValue;
            Steps = 0;
            Max = initialValue;
            Values = new List<int> { initialValue };
        }

        public void Analyze()
        {
            Steps = (int)Values.Count - 1;
            Max = Values.Max();
        }
    }
}
