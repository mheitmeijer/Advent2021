﻿using Framework;
using Framework.Extensions;
using Framework.Interfaces;

namespace DayXXX
{
    public class Day : IDay
    {
        public double CalculatePart1()
        {
            var result = 0;
            return result;
        }

        public double CalculatePart2()
        {
            var result = 0;
            return result;
        }

        private List<int> GetInput()
        {
            var processor = new GenericFunctionFileProcessor<int>();
            var result = processor.GetContent(@".\Day5Input.txt", (line) =>
            {
                return line.ToInt();
            });
            return result;
        }
    }
}