using Framework;
using Framework.Interfaces;

namespace Day008
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            var result = 0;
            var input = GetInput();
            result = input.Count();
            return result;
        }

        public long CalculatePart2()
        {
            long result = 0;
            var input = GetInput2();
            var wires = new Dictionary<int, char[]>();

            foreach (var currentInput in input)
            {
                var test = currentInput.Take(10);
                // one is the one with two characters
                var one = test.First(x => x.Length == 2);
                wires[1] = one.ToCharArray();

                var four = test.First(x => x.Length == 4);
                wires[4] = four.ToCharArray();

                var seven = test.First(x => x.Length == 3);
                wires[7] = seven.ToCharArray();

                var eight = test.First(x => x.Length == 7);
                wires[8] = eight.ToCharArray();

                // 9 = 4 and 7
                var nine = test.First(x => x.ToCharArray().Intersect(wires[4]).Count() == wires[4].Length
                    && x.ToCharArray().Intersect(wires[7]).Count() == wires[7].Length
                    && wires[8].Intersect(x.ToCharArray()).Count() != wires[8].Length);
                wires[9] = nine.ToCharArray();

                // 0 = contains 1 and  8 contains but not 9 contains
                var zero = test.First(x => wires[7].Intersect(x.ToCharArray()).Count() == 3
                    && x.ToCharArray().Intersect(wires[8]).Count() == 6
                    && wires[9].Intersect(x.ToCharArray()).Count() != wires[9].Length
                    && x.ToCharArray().Count() != wires[8].Count()
                    && x.ToCharArray().Count() != wires[7].Count());
                wires[0] = zero.ToCharArray();

                var three = test.First(x => x.ToCharArray().Intersect(wires[1]).Count() == wires[1].Length
                    && x.ToCharArray().Intersect(wires[7]).Count() == wires[7].Length
                    && wires[8].Intersect(x.ToCharArray()).Count() == 5
                    && wires[9].Intersect(x.ToCharArray()).Count() == 5);
                wires[3] = three.ToCharArray();

                var six = test.First(x => x.ToCharArray().Intersect(wires[1]).Count() == 1
                    && wires[8].Intersect(x.ToCharArray()).Count() == 6);

                wires[6] = six.ToCharArray();

                var two = test.First(x => x.ToCharArray().Intersect(wires[1]).Count() == 1
                    && wires[6].Intersect(x.ToCharArray()).Count() == 4);
                wires[2] = two.ToCharArray();

                var five = test.First(x => x.ToCharArray().Intersect(wires[1]).Count() == 1
                    && wires[9].Intersect(x.ToCharArray()).Count() == 5
                    && x.ToCharArray().Count() == 5);
                wires[5] = five.ToCharArray();

                var number = "";
                foreach (var digit in currentInput.Skip(10))
                {
                    foreach(var key in wires.Keys)
                    {
                        if(string.Concat(wires[key]) == digit)
                        {
                            number += key;
                            break;
                        }
                    }
                }
                result += Convert.ToInt64(number);

            }
            return result;
        }

        private List<string> GetInput()
        {
            var processor = new GenericFunctionFileProcessor<string>();
            var result = processor.GetContentSingleLine(@".\Day008Input.txt", (line) =>
            {
                var lengths = new[] { 2, 3, 4, 7 };
                var splittedOutput = line.Split(" | ");
                var correctLengthValues = splittedOutput[1].Split(" ").Where(x => lengths.Contains(x.Length));
                return correctLengthValues.ToList();
            });
            return result;
        }
        private List<List<string>> GetInput2()
        {
            var input = new List<List<string>>();
            string line;
            StreamReader file = new StreamReader(@"Day008Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                var result = new List<string>();
                var splittedOutput = line.Replace(" | ", " ");
                var singleValues = splittedOutput.Split(" ").Select(x => string.Concat(x.OrderBy(c => c)));
                result.AddRange(singleValues.ToList());
                input.Add(result);
            }

            return input;
        }
    }
}