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
            for (int row = 0; row < octopusses.GetLength(0); row++)
            {
                for (int column = 0; column < octopusses.GetLength(0); column++)
                {
                    octopusses[row, column].Value += 1;
                }
            }
            for (int row = 0; row < octopusses.GetLength(0); row++)
            {
                for (int column = 0; column < octopusses.GetLength(0); column++)
                {
                    DoFlash(octopusses[row, column]);
                }
            }
            return result;
        }

        private Octopus[,] ParseMap(long[][] map)
        {
            var result = new Octopus[ map.GetLength(0), map[0].GetLength(0)];
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map[0].Length; column++)
                {
                    var newOctopus = new Octopus { Row = row, Column = column, Value = map[row][column] };
                    result[row, column] = newOctopus;
                }
            }

            for (int row = 0; row < result.Rank; row++)
            {
                for (int column = 0; column < result.GetLength(row); column++)
                {
                    var rowLimit = result.Rank;
                    var columnLimit = result.GetLength(row);
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

        private void DoFlash(Octopus octopus)
        {
            if(octopus.Value == 9)
            {
                foreach(var neighbour in octopus.Neighbours)
                {
                    neighbour.Value += 1;

                }
            }
        }

        public long CalculatePart2()
        {
            long result = 0;
            return result;
        }

        private long[][] GetInput()
        {
            var result = new List<long[]>();
            string line;
            StreamReader file = new StreamReader(@"Day010Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line.ToCharArray().Select(x => x.ToLong()).ToArray());
            }

            return result.ToArray();
        }
    }
}