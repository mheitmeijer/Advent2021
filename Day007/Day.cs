using System.Linq;
using Framework;
using Framework.Extensions;
using Framework.Interfaces;
using Framework.MathExtensions;

namespace Day007
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            long result = 0;
            var input = GetInput();
            var maxPosition = input.Max();
            long currentMinimum = 0;

            for(var currentPosition = 1; currentPosition < maxPosition;currentPosition++)
            {
                var current = CalculateMovementCost(input, currentPosition);
                if(current < currentMinimum || currentMinimum == 0)
                {
                    currentMinimum = current;
                }
            }
            result = currentMinimum;
            return result;
        }

        private long CalculateMovementCost(List<long> positions, long currentPosition)
        {
            long costs = 0;
            foreach (var currentCosts in from position in positions
                                         let currentCosts = Math.Abs(currentPosition - position)
                                         select currentCosts)
            {
                costs += currentCosts;
            }

            return costs;
        }
        public long CalculatePart2()
        {
            long result = 0;
            var input = GetInput();
            var maxPosition = input.Max();
            long currentMinimum = 0;

            for (var currentPosition = 1; currentPosition < maxPosition; currentPosition++)
            {
                var current = CalculateMovementCost2(input, currentPosition);
                if (current < currentMinimum || currentMinimum == 0)
                {
                    currentMinimum = current;
                }
            }
            result = currentMinimum;
            return result;
        }

        private long CalculateMovementCost2(List<long> positions, long currentPosition)
        {
            long costs = 0;
            foreach (var position in positions)
            {
                var steps = Math.Abs(position - currentPosition);
                var currentCosts = steps.CalculateTriangularNumber();
                costs += currentCosts;
            }

            return costs;
        }

        private List<long> GetInput()
        {
            var processor = new GenericFunctionFileProcessor<long>();
            var result = processor.GetContentSingleLine(@".\Day007Input.txt", (line) =>
            {
                return line.Split(",").Select(x => x.ToLong()).ToList();
            });
            return result;
        }
    }
}