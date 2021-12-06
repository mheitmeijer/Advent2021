using Framework;
using Framework.Interfaces;
using Framework.Extensions;
namespace Day005
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            var input = GetInput();
            var dimension = 1000;
            var map = new int[dimension, dimension];
            foreach (var coords in input)
            {
                if (coords.Item2 == coords.Item4)
                {
                    DrawHorizontal(map, coords.Item1, coords.Item2, coords.Item3, coords.Item4);
                }
                else if (coords.Item1 == coords.Item3)
                {
                    DrawVertical(map, coords.Item1, coords.Item2, coords.Item3, coords.Item4);
                }
                else if(Math.Abs(coords.Item1 - coords.Item3) == Math.Abs(coords.Item4 - coords.Item2))
                {
                    DrawDiagonal(map, coords.Item1, coords.Item2, coords.Item3, coords.Item4);
                }
            }
            DrawMap(map);
            var xIterator = 0;
            var hit = 0;
            while (xIterator < dimension)
            {
                int yIterator = 0;
                while (yIterator < dimension)
                {
                    if (map[xIterator, yIterator] > 1)
                    {
                        hit++;
                    }
                    yIterator++;
                }
                xIterator++;
            }
            return hit;
        }

        private static void DrawMap(int[,] map)
        {
            var yIterator = 0;
            while (yIterator <= 9)
            {
                int xIterator = 0;
                while (xIterator <= 9)
                {
                    if (map[xIterator, yIterator] == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(map[xIterator, yIterator]);
                    }
                    xIterator++;
                }
                Console.WriteLine();
                yIterator++;
            }
        }

        private static void DrawDiagonal(int[,] map, int x1, int y1, int x2, int y2)
        {
            var xSteps = Math.Abs(x1 - x2);
            var xDirection = x1 > x2 ? -1 : 1;
            var xStepCounter = 0;
            var currentX = x1;

            var yDirection = y1 > y2 ? -1 : 1;
            var currentY = y1;

            while(xStepCounter <= xSteps)
            {
                map[currentX, currentY] += 1;
                currentX += xDirection;
                currentY += yDirection;
                xStepCounter++;
            }
        }

        private static void DrawVertical(int[,] map, int x1, int y1, int x2, int y2)
        {
            // X are the same
            // Starting point is the least of Y
            var startY = Math.Min(y1, y2);
            var endY = Math.Max(y2, y1);
            var yIterator = startY;
            while (yIterator <= endY)
            {
                map[x1, yIterator]++;
                yIterator++;
            }
        }

        private static void DrawHorizontal(int[,] map, int x1, int y1, int x2, int y2)
        {
            // Y are the same
            // Starting point is the least of x
            var startX = Math.Min(x1, x2);
            var endX = Math.Max(x1, x2);
            var xIterator = startX;
            while (xIterator <= endX)
            {
                map[xIterator, y1]++;
                xIterator++;
            }
        }

        public long CalculatePart2()
        {
            return 0;
        }

        private List<(int, int, int, int)> GetInput()
        {
            var processor = new GenericFunctionFileProcessor<(int, int, int, int)>();
            var result = processor.GetContent(@".\Day5Input.txt", (line) =>
            {
                var replaced = line.Replace(" -> ", ",");
                var splitted = replaced.Split(",");
                var n1 = splitted[0].ToInt();
                var n2 = splitted[1].ToInt();
                var n3 = splitted[2].ToInt();
                var n4 = splitted[3].ToInt();

                return new(n1, n2, n3, n4);
            });
            return result;
        }
    }
}