using Framework;
using Framework.Extensions;
using Framework.Interfaces;

namespace Day007
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
            var result = processor.GetContent(@".\Day007Input.txt", (line) =>
            {
                return line.ToInt();
            });
            return result;
        }
    }
}