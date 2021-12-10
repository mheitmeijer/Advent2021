using Framework;
using Framework.Extensions;
using Framework.Interfaces;

namespace Day010
{
    public class Day : IDay
    {
        public long CalculatePart1()
        {
            long result = 0;
            var input = GetInput();
            var stack = new List<char>();
            var openingCharacters = new char[] { '(', '[', '{', '<' };
            var closingCharacters = new char[] { ')', ']', '}', '>' };
            var expectedClosing = new Dictionary<char, char>();
            expectedClosing.Add('(', ')');
            expectedClosing.Add('[', ']');
            expectedClosing.Add('{', '}');
            expectedClosing.Add('<', '>');

            var incorrectCharacters = new List<char>();

            var incorrectClosingCharacterScore = new Dictionary<char, long>();
            incorrectClosingCharacterScore.Add(')', 3);
            incorrectClosingCharacterScore.Add(']', 57);
            incorrectClosingCharacterScore.Add('}', 1197);
            incorrectClosingCharacterScore.Add('>', 25137);

            foreach (var line in input)
            {
                stack.Clear();
                foreach(var currentChar in line.ToCharArray())
                {
                    if(stack.Count() == 0)
                    {
                        stack.Add(currentChar);
                        continue;
                    }
                    if(openingCharacters.Contains(currentChar))
                    {
                        stack.Add(currentChar);
                        continue;
                    }
                    if(closingCharacters.Contains(currentChar))
                    {
                        // peek
                        var lastCharacter = stack[stack.Count() - 1];
                        if(expectedClosing[lastCharacter] == currentChar)
                        {
                            stack.RemoveAt(stack.Count() - 1);
                            continue;
                        }

                        incorrectCharacters.Add(currentChar);
                        result += incorrectClosingCharacterScore[currentChar];
                        Console.WriteLine(line);
                        Console.WriteLine($"Expected {expectedClosing[lastCharacter]}, but found {currentChar} instead");
                        stack.Clear();
                        break;
                    }
                }
            }
            return result;
        }

        public long CalculatePart2()
        {
            long result = 0;
            var input = GetInput();
            var stack = new List<char>();
            var openingCharacters = new char[] { '(', '[', '{', '<' };
            var closingCharacters = new char[] { ')', ']', '}', '>' };
            var expectedClosing = new Dictionary<char, char>();
            expectedClosing.Add('(', ')');
            expectedClosing.Add('[', ']');
            expectedClosing.Add('{', '}');
            expectedClosing.Add('<', '>');

            var incorrectCharacters = new List<char>();

            var incorrectClosingCharacterScore = new Dictionary<char, long>();
            incorrectClosingCharacterScore.Add(')', 3);
            incorrectClosingCharacterScore.Add(']', 57);
            incorrectClosingCharacterScore.Add('}', 1197);
            incorrectClosingCharacterScore.Add('>', 25137);

            var completionCharacterScore = new Dictionary<char, long>();
            completionCharacterScore.Add(')', 1);
            completionCharacterScore.Add(']', 2);
            completionCharacterScore.Add('}', 3);
            completionCharacterScore.Add('>', 4);
            var completionScores = new List<long>();
            foreach (var line in input)
            {
                stack.Clear();
                foreach (var currentChar in line.ToCharArray())
                {
                    if (stack.Count() == 0)
                    {
                        stack.Add(currentChar);
                        continue;
                    }
                    if (openingCharacters.Contains(currentChar))
                    {
                        stack.Add(currentChar);
                        continue;
                    }
                    if (closingCharacters.Contains(currentChar))
                    {
                        // peek
                        var lastCharacter = stack[stack.Count() - 1];
                        if (expectedClosing[lastCharacter] == currentChar)
                        {
                            stack.RemoveAt(stack.Count() - 1);
                            continue;
                        }

                        incorrectCharacters.Add(currentChar);
                        result += incorrectClosingCharacterScore[currentChar];
                        Console.WriteLine(line);
                        Console.WriteLine($"Expected {expectedClosing[lastCharacter]}, but found {currentChar} instead");
                        stack.Clear();
                        break;
                    }
                }

                if (stack.Count() > 0)
                {
                    Console.Write($"Completing {line}: ");
                    long currentScore = 0;
                    while (stack.Count() > 0)
                    {
                        var lastCharacter = stack[stack.Count() - 1];
                        var expectedCharacter = expectedClosing[lastCharacter];
                        Console.Write(expectedCharacter);
                        currentScore *= 5;
                        currentScore += completionCharacterScore[expectedCharacter];

                        stack.RemoveAt(stack.Count() - 1);
                    }
                    completionScores.Add(currentScore);

                }
            }
            var orderdScores = completionScores.OrderBy(x => x).ToList();
            result = orderdScores[orderdScores.Count() / 2];
            return result;
        }

        private List<string> GetInput()
        {
            var processor = new StringFileProcessor();
            var result = processor.GetContent(@".\Day010Input.txt");
            return result;
        }
    }
}