using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent03
{
    internal class Adventer
    {
        public void DoIt()
        {
            Calculate2();
            Console.ReadLine();
        }

        public void Calculate2()
        {
            var input = GetInput();
            var currentComparison = 2048;// Convert.ToInt32("10000", 2);
                                         //var currentComparison = 16;

            while (input.Count > 1)
            {
                var oneList = new List<int>();
                var zeroList = new List<int>();
                var currentIndex = 0;
                while (currentIndex < input.Count)
                {
                    var item = input[currentIndex];
                    if ((item & currentComparison) == 0)
                    {
                        zeroList.Add(item);
                    }
                    else
                    {
                        oneList.Add(item);
                    }
                    currentIndex++;
                }
                if (oneList.Count >= zeroList.Count)
                {
                    input = new List<int>(oneList);
                }
                else
                {
                    input = new List<int>(zeroList);
                }
                currentComparison >>= 1;
            }
            var gamma = input[0];
            Console.WriteLine($"Gamma: {gamma} ");

            input = GetInput();
            currentComparison = 2048;
            while (input.Count > 1)
            {
                var oneList = new List<int>();
                var zeroList = new List<int>();
                var currentIndex = 0;
                while (currentIndex < input.Count)
                {
                    var item = input[currentIndex];
                    if ((item & currentComparison) == 0)
                    {
                        zeroList.Add(item);
                    }
                    else
                    {
                        oneList.Add(item);
                    }
                    currentIndex++;
                }
                if (zeroList.Count <= oneList.Count)
                {
                    input = new List<int>(zeroList);
                }
                else
                {
                    input = new List<int>(oneList);
                }
                currentComparison >>= 1;
            }

            var epsilon = input[0];
            Console.WriteLine($"Epsilon: {epsilon} ");
            Console.WriteLine($"Result: {gamma * epsilon}");
        }

        public void Calculate1()
        {
            var input = GetInput();
            var gamma = "";
            var epsilon = "";
            var currentComparison = 2048;// Convert.ToInt32("10000", 2);

            while (currentComparison > 0)
            {
                var countZero = 0;
                var countOne = 0;
                foreach (var item in input)
                {
                    if ((item & currentComparison) == 0)
                    {
                        countZero++;
                    }
                    else
                    {
                        countOne++;
                    }
                }
                if (countOne > countZero)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
                currentComparison >>= 1;
            }
            Console.WriteLine($"Gamma: {gamma} = {Convert.ToInt32(gamma, 2)}");
            Console.WriteLine($"Epsilon: {epsilon} = {Convert.ToInt32(epsilon, 2)}");
            Console.WriteLine($"Result: {Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)}");
        }

        private static List<int> GetInput()
        {
            var result = new List<int>();
            StreamReader file = new StreamReader(@"Input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {

                result.Add(Convert.ToInt32(line, 2));
            }
            return result;
        }
    }
}
