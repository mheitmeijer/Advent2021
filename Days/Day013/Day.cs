using Framework.Extensions;
using Framework.Interfaces;

namespace Day013
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            var folds = new List<(string, int)>();
            var input = GetInput(folds);

            var maxX = input.Max(x => x.Item1);
            var maxY = input.Max(y => y.Item2);

            foreach (var fold in folds)
            {
                if (fold.Item1 == "y")
                {
                    for(int i = 0; i < input.Count; i++)
                    {
                        var item = input[i];
                        if (item.Item2 > fold.Item2)
                        {
                            item.Item2 = fold.Item2 - (item.Item2 - fold.Item2);
                            input[i] = item;
                        }
                    }
                }
                else if (fold.Item1 == "x")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        var item = input[i];
                        if (item.Item1 > fold.Item2)
                        {
                            item.Item1 = fold.Item2 - (item.Item1 - fold.Item2);
                            input[i] = item;
                        }
                    }
                }
                
                // Generate a copy of the list 
                var copy = new List<(int, int)>();
                foreach(var item in input)
                {
                    if(!copy.Any(x => x.Item1 == item.Item1 && x.Item2 == item.Item2 ))
                    {
                        copy.Add(item);
                    }
                }
                input = copy;
            }
            return input.Count;
        }

        public long CalculatePart2()
        {
            var folds = new List<(string, int)>();
            var input = GetInput(folds);

            foreach (var fold in folds)
            {
                if (fold.Item1 == "y")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        var item = input[i];
                        if (item.Item2 > fold.Item2)
                        {
                            item.Item2 = fold.Item2 - (item.Item2 - fold.Item2);
                            input[i] = item;
                        }
                    }
                }
                else if (fold.Item1 == "x")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        var item = input[i];
                        if (item.Item1 > fold.Item2)
                        {
                            item.Item1 = fold.Item2 - (item.Item1 - fold.Item2);
                            input[i] = item;
                        }
                    }
                }
            }

            input = input.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
            var maxX = input.Max(x => x.Item1);
            var maxY = input.Max(y => y.Item2);
            for(int row = 0; row <= maxY; row++)
            {
                for(int col = 0; col <= maxX; col++)
                {
                    if(input.Any(x => x.Item1 == col && x.Item2 == row))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            return input.Count;
        }

        private List<(int, int)> GetInput(List<(string, int)> folds)
        {
            var result = new List<(int, int)>();
            string line;
            var file = new StreamReader(@"Day013Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                if (!line.StartsWith("fold"))
                {
                    var splitted = line.Split(",");
                    result.Add(new(splitted[0].ToInt(), splitted[1].ToInt()));
                    continue;
                }

                var fold = line[11..];
                var splittedFold = fold.Split("=");
                folds.Add(new(splittedFold[0], splittedFold[1].ToInt()));
            }

            return result;
        }
    }
}