using Framework;
using Framework.Extensions;
using Framework.Interfaces;
using System.Collections;

namespace Day006
{
    public class Day : IDay
    {
        public double CalculatePart1()
        {
            var result = 0;
            var fishes = GetInput();
            foreach (var fish in fishes)
            {
                Console.Write($"{fish},");
            }
            for (int dayCounter = 0; dayCounter < 256; dayCounter++)
            {
                Console.WriteLine($"Day {dayCounter}");
                var fishCount = fishes.Count;
                for (int fishIndex = 0; fishIndex < fishCount; fishIndex++)
                {
                    fishes[fishIndex]--;
                    if (fishes[fishIndex] == 255)
                    {
                        fishes[fishIndex] = 6;
                        fishes.Add(8);
                    }

                }
                //foreach (var fish in fishes)
                //{
                //    Console.Write($"{fish},");
                //}
            }
            result = fishes.Count;
            return result;
        }

        public double CalculatePart2()
        {
            double result = 0;
            var fishes = GetInput();

            var pools = new Dictionary<int, double>() {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };
            foreach (var fish in fishes)
            {
                pools[fish]++;
            }

            for (int dayCounter = 0; dayCounter < 256; dayCounter++)
            {
                var babyFishes = pools[0];
                for (int poolIndex = 0; poolIndex < pools.Count -1;poolIndex++)
                {
                    pools[poolIndex] = pools[poolIndex + 1];
                }
                pools[6] += babyFishes;
                pools[8] = babyFishes;
            }

            var total = pools.Values.Sum();
            Console.WriteLine(total);
            return Convert.ToInt32(total);
        }

        //public int CalculatePart2()
        //{
        //    double result = 0;
        //    var fishes = GetInput();

        //    var tasks = new List<Task<double>>();
        //    foreach(var fish in fishes)
        //    {
        //        tasks.Add(Task<double>.Factory.StartNew((fish) => {
        //            var fishes = new List<byte>();
        //            fishes.Add((byte)fish);
        //            for (int dayCounter = 0; dayCounter < 256; dayCounter++)
        //            {
        //                //Console.WriteLine($"Day {dayCounter}");
        //                var fishCount = fishes.Count;
        //                for (int fishIndex = 0; fishIndex < fishCount; fishIndex++)
        //                {
        //                    fishes[fishIndex]--;
        //                    if (fishes[fishIndex] == 255)
        //                    {
        //                        fishes[fishIndex] = 6;
        //                        fishes.Add(8);
        //                    }
        //                }
        //            }
        //            return Convert.ToDouble(fishes.Count());

        //        }, fish));
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    foreach(var task in tasks)
        //    {
        //        result += task.Result;
        //    }
        //    result = fishes.Count;
        //    Console.WriteLine(result);
        //    return Convert.ToInt32(result);
        //}

        private int SpawnFish(byte day)
        {
            var fishes = new List<byte>(day);
            for (int dayCounter = 0; dayCounter < 256; dayCounter++)
            {
                Console.WriteLine($"Day {dayCounter}");
                var fishCount = fishes.Count;
                for (int fishIndex = 0; fishIndex < fishCount; fishIndex++)
                {
                    fishes[fishIndex]--;
                    if (fishes[fishIndex] == 255)
                    {
                        fishes[fishIndex] = 6;
                        fishes.Add(8);
                    }
                }
                //foreach (var fish in fishes)
                //{
                //    Console.Write($"{fish},");
                //}
            }
            return fishes.Count();
        }

        private List<Byte> GetInput()
        {
            var processor = new GenericFunctionFileProcessor<byte>();
            var result = processor.GetContentSingleLine(@".\Day006Input.txt", (line) =>
            {
                var splitted = line.Split(",");
                return splitted.Select(x => x.ToByte()).ToList();
            });
            return result;
        }
    }
}