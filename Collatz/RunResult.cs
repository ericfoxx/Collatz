using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz
{
    public class RunResult
    {
        public long InitialValue { get; private set; }
        public long Steps { get; set; }
        public long Max { get; set; }
        public List<long> Values { get; set; }
        public RunResult(long initialValue) 
        { 
            InitialValue = initialValue;
            Steps = 0;
            Max = initialValue;
            Values = new List<long> { initialValue };
        }

        public void Analyze()
        {
            Steps = Values.Count - 1;
            Max = Values.Max();
        }
    }
}
