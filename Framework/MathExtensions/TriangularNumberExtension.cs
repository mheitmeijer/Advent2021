using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.MathExtensions
{
    public static class TriangularNumberExtension
    {
        //https://www.mathsisfun.com/algebra/triangular-numbers.html

        public static long CalculateTriangularNumber(this long input)
        {
            return input * (input + 1) / 2;
        }
    }
}
