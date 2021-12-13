namespace Day011
{
    internal class Octopus
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public long Value { get; set; }
        public bool Flashed { get; set; }
        public List<Octopus> Neighbours { get; set; }

        public void Increase()
        {
            Value += 1;
        }
    }
}
