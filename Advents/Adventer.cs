using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advents
{
    internal class Adventer
    {
        public void DoIt()
        {
            //Calculate1();
            Calculate2();
        }

        private void Calculate2()
        {
            var input = GetInput();

            var currentIndex = 0;
            var previousWindowSum = 0;
            var currentWindowSum = 0;
            var countIncreased = 0;
            while(true)
            {
                currentWindowSum = GetWindowSum(input, currentIndex);
                if(currentWindowSum == -1)
                {
                    break;
                }
                if(currentIndex > 0 && currentWindowSum > previousWindowSum)
                {
                    countIncreased++;
                }
                previousWindowSum = currentWindowSum;
                currentIndex++;
            }
            Console.Write($"{countIncreased}");
        }

        private int GetWindowSum(List<int> input, int currentIndex)
        {
            if(currentIndex + 2 >= input.Count)
            {
                return -1;
            }

            return input[currentIndex] + input[currentIndex + 1] + input[currentIndex + 2];
        }

        private void Calculate1()
        {
            var input = GetInput();
            var countIncreased = 0;
            var previousValue = 0;
            var currentValue = 0;
            var currentIndex = 0;

            while(currentIndex < input.Count)
            {
                currentValue = input[currentIndex];
                if(currentIndex == 0)
                {
                    previousValue = input[currentIndex];
                    currentIndex++;
                    continue;
                }
                if(currentValue > previousValue)
                {
                    countIncreased++;
                }

                currentIndex++;
                previousValue = currentValue;
            }
            Console.Write($"{countIncreased}");
        }

        private List<int> GetInput()
        {
            var result = new List<int>();
            StreamReader file = new StreamReader(@".\Input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
              
                result.Add(Convert.ToInt32(line));
            }

            return result;
        }
    }
}
