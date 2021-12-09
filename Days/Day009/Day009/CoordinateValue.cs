using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day009
{
    internal class CoordinateValue
    {
        public long Row { get; set; }
        public long Column { get; set; }
        public long Value { get; set; }

        public override string ToString()
        {
            return $"{Row}_{Column}_{Value}";
        }
    }
}
