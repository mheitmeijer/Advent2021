namespace Advent02
{
    internal class Adventer
    {
        public void DoIt()
        {
            //Calculate1();
            Calculate2();
        }

        private void Calculate2()
        {
            var input = GetInput();
            var horizontal = 0;
            var depth = 0;
            var aim = 0;
            foreach (var move in input)
            {
                switch (move.Item1)
                {
                    case "forward":
                        horizontal += move.Item2;
                        depth += aim * move.Item2;
                        break;
                    case "down":
                        aim += move.Item2;
                        break;
                    case "up":
                        aim -= move.Item2;
                        break;
                }
            }
            Console.WriteLine($"Horizontal: {horizontal}");
            Console.WriteLine($"Depth: {depth}");
            Console.Write($"Result: {horizontal * depth}");
        }

        //private int GetWindowSum(List<int> input, int currentIndex)
        //{
        //    if (currentIndex + 2 >= input.Count)
        //    {
        //        return -1;
        //    }

        //    return input[currentIndex] + input[currentIndex + 1] + input[currentIndex + 2];
        //}

        private void Calculate1()
        {
            var input = GetInput();
            var horizontal = 0;
            var depth = 0;
            foreach(var move in input)
            {
                switch(move.Item1)
                {
                    case "forward":
                        horizontal += move.Item2;
                        break;
                    case "down":
                        depth += move.Item2;
                        break;
                    case "up":
                        depth -= move.Item2;
                        break;
                }
            }
            Console.WriteLine($"Horizontal: {horizontal}");
            Console.WriteLine($"Depth: {depth}");
            Console.Write($"Result: {horizontal * depth}");
        }

        private List<(string, int)> GetInput()
        {
            var result = new List<(string, int)>();
            StreamReader file = new StreamReader(@".\Input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var splitted = line.Split(' ');
                var direction = splitted[0];
                var steps = splitted[1];
                result.Add((direction, Convert.ToInt32(steps)));
            }

            return result;
        }
    }
}
