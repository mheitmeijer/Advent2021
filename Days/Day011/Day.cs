using Framework.Extensions;
using Framework.Interfaces;

namespace Day011
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            long result = 0;
            var input = GetInput();
            var octopusses = ParseMap(input);
            

            for (int step = 1; step <= 100; step++)
            {

                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        octopusses[row, column].Value += 1;
                        octopusses[row, column].Flashed = false;
                    }
                }

                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        result += DoFlash(octopusses[row, column]);
                    }
                }
                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        octopusses[row, column].Value = octopusses[row, column].Value > 9 ? 0 : octopusses[row, column].Value;
                    }
                }
                Console.WriteLine($"After step {step}:");
            }
            return result;
        }

        private long DoFlash(Octopus octopus)
        {
            long nrOfFlashes = 0;
            if (octopus.Value > 9 && !octopus.Flashed)
            {
                octopus.Flashed = true;
                nrOfFlashes++;
                foreach (var neighbour in octopus.Neighbours)
                {
                    neighbour.Value += 1;
                }
                foreach (var neighbour in octopus.Neighbours)
                {
                    nrOfFlashes += DoFlash(neighbour);
                }
            }
            return nrOfFlashes;
        }

        private Octopus[,] ParseMap(long[][] map)
        {
            var result = new Octopus[map.GetLength(0), map[0].GetLength(0)];
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map[0].Length; column++)
                {
                    var newOctopus = new Octopus { Row = row, Column = column, Value = map[row][column], Neighbours = new List<Octopus>() };
                    result[row, column] = newOctopus;
                }
            }

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map[0].Length; column++)
                {
                    var rowLimit = result.GetLength(0) - 1;
                    var columnLimit = result.GetLength(0) - 1;
                    for (var x = Math.Max(0, row - 1); x <= Math.Min(row + 1, rowLimit); x++)
                    {
                        for (var y = Math.Max(0, column - 1); y <= Math.Min(column + 1, columnLimit); y++)
                        {
                            if (x != row || y != column)
                            {
                                result[row, column].Neighbours.Add((result[x, y]));
                            }
                        }
                    }
                }
            }

            return result;
        }


        public long CalculatePart2()
        {
            var input = GetInput();
            var octopusses = ParseMap(input);

            var totalOctopusses = octopusses.Length;
            var step = 1;

            while(true)
            {

                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        octopusses[row, column].Value += 1;
                        octopusses[row, column].Flashed = false;
                    }
                }

                long result = 0;
                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        result += DoFlash(octopusses[row, column]);
                    }
                }
                if (result == totalOctopusses)
                {
                    Console.WriteLine($"All Flashed after step {step}.");
                    return step;
                }
                for (int row = 0; row < octopusses.GetLength(0); row++)
                {
                    for (int column = 0; column < octopusses.GetLength(0); column++)
                    {
                        octopusses[row, column].Value = octopusses[row, column].Value > 9 ? 0 : octopusses[row, column].Value;
                    }
                }
                Console.WriteLine($"After step {step}:");
                step++;
            }
        }

        private long[][] GetInput()
        {
            var result = new List<long[]>();
            string line;
            StreamReader file = new StreamReader(@"Day011Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line.ToCharArray().Select(x => x.ToLong()).ToArray());
            }

            return result.ToArray();
        }
    }
}