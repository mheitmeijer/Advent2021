using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent05
{
    internal class Adventer
    {
        public void DoIt()
        {
            Calculate1();
            Calculate2();
        }

        private void Calculate2()
        {
            
        }

        
        private void Calculate1()
        {
            var input = GetInput();
            
        }

        private List<(string, int)> GetInput()
        {
            var result = new List<(string, int)>();
            StreamReader file = new StreamReader(@".\Input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var splitted = line.Split(' ');
                var direction = splitted[0];
                var steps = splitted[1];
                result.Add((direction, Convert.ToInt32(steps)));
            }

            return result;
        }
    }
}
