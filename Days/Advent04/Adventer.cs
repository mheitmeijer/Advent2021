using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent04
{
    internal class Adventer
    {
        public void DoIt()
        {
            Calculate2();
            Console.ReadLine();
        }

        public void Calculate2()
        {
            var cards = new List<Card>();
            var input = GetInput(cards);
            Card lastWon = null;
            int lastNumberWon = 0;
            foreach (var number in input)
            {
                foreach (var card in cards)
                {
                    if(card.Skip)
                    {
                        continue;
                    }

                    var hasBingo = card.Mark(number);
                    if (hasBingo)
                    {
                        lastWon = card;
                        lastNumberWon = number;
                        card.Skip = true;
                    }
                }
            }
            Console.WriteLine("Bingo");
            Console.WriteLine($"Score: {lastNumberWon * lastWon.GetUnmarkedScore()}");
        }

        public void Calculate1()
        {
            var cards = new List<Card>();
            var input = GetInput(cards);
            foreach(var number in input)
            {
                foreach(var card in cards)
                {
                    var hasBingo = card.Mark(number);
                    if(hasBingo)
                    {
                        Console.WriteLine("Bingo");
                        Console.WriteLine($"Score: {number * card.GetUnmarkedScore()}");
                        return;
                    }
                }
            }
        }

        private static List<int> GetInput(List<Card> cards)
        {
            var result = new List<int>();
            StreamReader file = new StreamReader(@"Input.txt");
            string line;

            var bingoInputNumbers = file.ReadLine().Split(",").Select(x => Convert.ToInt32(x)).ToList();
            file.ReadLine();
            var bingoNumbers = new List<BingoNumber>();
            //var cards = new List<Card>();
            var row = 0;
            while ((line = file.ReadLine()) != null)
            {
                if(string.IsNullOrEmpty(line))
                {
                    row = 0;
                    cards.Add(new Card { BingoNumbers = bingoNumbers });
                    bingoNumbers = new List<BingoNumber>();
                    continue;
                }
                line = line.Replace("  ", " ");
                if(line[0] == ' ')
                {
                    line = line.Substring(1);
                }
                line = line.Replace(" ", ",");
                bingoNumbers.AddRange(line.Split(",").Select(
                    (x, i) => new BingoNumber 
                    { Col = i, Number = Convert.ToInt32(x), Row = row}
                    ));
                row++;
            }
            return bingoInputNumbers;
        }
    }
}
