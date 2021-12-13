using Framework.Extensions;
using Framework.Interfaces;

namespace Day009
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            long riskLevels = 0;
            var map = GetInput();
            
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for(int col =0; col < map[0].Length; col++)
                {
                    var currentPoint = map[row][col];
                    var neighbours = GetHorizontalAndVerticalNeighbours(map, row, col);
                    if(currentPoint < neighbours.Min())
                    {
                        riskLevels += currentPoint + 1;
                    }
                }
            }
            return riskLevels;
        }

        private List<long> GetHorizontalAndVerticalNeighbours(long[][] map, int row, int col)
        {
            var result = new List<long>();
            var rowLength = map[0].Length;
            var numberOfRows = map.GetLength(0);
            var testRow = row - 1;
            // one up
            testRow = row - 1;
            if(testRow >= 0)
            {
                result.Add(map[testRow][col]);
            }
            // left
            var testCol = col - 1;
            if(testCol >= 0)
            {
                result.Add(map[row][testCol]);
            }
            // right
            testCol = col + 1;
            if(testCol < rowLength)
            {
                result.Add(map[row][testCol]);
            }

            // down
            testRow = row + 1;
            if(testRow < numberOfRows)
            {
                result.Add(map[testRow][col]);
            }
            return result;
        }

        public long CalculatePart2()
        {
            long result = 0;
            var map = GetInput();
            var basins = new List<List<string>>();
            var basinsWithCoordinates = new List<List<CoordinateValue>>();

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map[0].Length; col++)
                {
                    var currentPoint = new CoordinateValue { Row = row, Column = col, Value = map[row][col] };
                    if(currentPoint.Value == 9)
                    {
                        continue;
                    }
                    var neighbours = GetHorizontalAndVerticalNeighboursCoordinates(map, row, col);
                    if(neighbours.Any(x => x.Value < 9 && x.Value - currentPoint.Value <= 1))
                    {
                        var coordinatesToCheck = neighbours.Where(x => x.Value < 9 && x.Value - currentPoint.Value <= 1).ToList();
                        coordinatesToCheck.Add(currentPoint);

                        // Test if there is a basin with one of the neighbours
                        var basin2 = basinsWithCoordinates.Where(b => b.Intersect(coordinatesToCheck, new CoordinateValueComparer()).Count() > 0);
                        List<CoordinateValue> basinWithCoordinatesToAddTo = null;
                        
                        if(basin2.Count() > 1)
                        {
                            // merge the basins
                            var newBasin = new List<CoordinateValue>();
                            foreach(var b in basin2)
                            {
                                newBasin.AddRange(b);
                                b.Clear();
                            }
                            basinWithCoordinatesToAddTo = newBasin;
                            basinsWithCoordinates.Add(basinWithCoordinatesToAddTo);
                        }
                        else if(basin2.Count() == 1)
                        {
                            basinWithCoordinatesToAddTo = basin2.First();
                        }
                        
                        if(basinWithCoordinatesToAddTo == null)
                        {
                            var newBasinWithCoordinates = new List<CoordinateValue>();
                            basinWithCoordinatesToAddTo = newBasinWithCoordinates;
                            basinsWithCoordinates.Add(basinWithCoordinatesToAddTo);
                        }

                        var allCorrectCoordinates = neighbours.Where(x => x.Value < 9 && x.Value - currentPoint.Value <= 1).Select(x => x).ToList();
                        allCorrectCoordinates.Add(currentPoint);
                        var filteredCoordinates = allCorrectCoordinates.Except(basinWithCoordinatesToAddTo, new CoordinateValueComparer());
                        basinWithCoordinatesToAddTo.AddRange(filteredCoordinates);
                    }
                }
            }

            var mergedBasins = new List<List<CoordinateValue>>();

            basinsWithCoordinates.RemoveAll(x => x.Count() == 0);

            while(basinsWithCoordinates.Count > 0)
            {
                
                var currentBasin = basinsWithCoordinates[0];
                var newBasin = new List<CoordinateValue>();
                newBasin.AddRange(currentBasin);
                for (int basinIndex = 1; basinIndex < basinsWithCoordinates.Count; basinIndex++)
                {
                    if(basinsWithCoordinates[basinIndex].Intersect(currentBasin).Count() > 0)
                    {
                        newBasin.AddRange(basinsWithCoordinates[basinIndex]);
                        basinsWithCoordinates[basinIndex].Clear();
                    }
                }
                mergedBasins.Add(newBasin);
                basinsWithCoordinates.RemoveAt(0);
            }

            var largestBasins = mergedBasins.OrderByDescending(x => x.Count()).Take(3);
            result = 1;
            foreach(var basin in largestBasins)
            {
                result *= basin.Count();
            }
            var mdLines = new List<string>();
            //foreach(var basin in basins)
            //{
            //    mdLines.Add(basin.Concat())
            //}
            return result;
        }

        private List<CoordinateValue> GetHorizontalAndVerticalNeighboursCoordinates(long[][] map, int row, int col)
        {
            var result = new List<CoordinateValue>();
            var rowLength = map[0].Length;
            var numberOfRows = map.GetLength(0);
            var testRow = row - 1;
            // one up
            testRow = row - 1;
            if (testRow >= 0)
            {
                result.Add(new CoordinateValue { Column = col, Row = testRow, Value = map[testRow][col] });
            }
            // left
            var testCol = col - 1;
            if (testCol >= 0)
            {
                result.Add(new CoordinateValue { Column = testCol, Row = row, Value = map[row][testCol] });
            }
            // right
            testCol = col + 1;
            if (testCol < rowLength)
            {
                result.Add(new CoordinateValue { Column = testCol, Row = row, Value = map[row][testCol] });
            }

            // down
            testRow = row + 1;
            if (testRow < numberOfRows)
            {
                result.Add(new CoordinateValue { Column = col, Row = testRow, Value = map[testRow][col] });
            }
            return result;
        }
        private long[][] GetInput()
        {
            var result = new List<long[]>();
            string line;
            StreamReader file = new StreamReader(@"Day009Input.txt");
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line.ToCharArray().Select(x => x.ToLong()).ToArray());
            }

            return result.ToArray();
        }
    }
}