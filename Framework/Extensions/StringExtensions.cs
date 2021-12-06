using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string input)
        {
            return Convert.ToInt32(input);
        }
        public static byte ToByte(this string input)
        {
            return Convert.ToByte(input);
        }
        public static long ToLong(this string input)
        {
            return Convert.ToInt64(input);
        }
    }
}
