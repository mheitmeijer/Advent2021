namespace Advent04
{
    internal class Card
    {
        public List<BingoNumber> BingoNumbers { get; set; }
        public bool Skip { get; set; }

        public bool Mark(int number)
        {
            var hit = BingoNumbers.FirstOrDefault(x => x.Number == number);
            if(hit != null)
            {
                hit.Marked = true;
                if (BingoNumbers.Count(x => x.Marked && x.Row == hit.Row) == 5
                    || BingoNumbers.Count(x => x.Marked && x.Col == hit.Col) == 5)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetUnmarkedScore()
        {
            var sumUnmarked = BingoNumbers.Sum(x => x.Marked ? 0 : x.Number);
            return sumUnmarked;
        }

        public bool HasBingo()
        {
            foreach(var markedNumber in BingoNumbers.Where(x => x.Marked))
            {
                if(BingoNumbers.Count(x => x.Marked && x.Row == markedNumber.Row) == 5 
                    || BingoNumbers.Count(x => x.Marked && x.Col == markedNumber.Col) == 5)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
