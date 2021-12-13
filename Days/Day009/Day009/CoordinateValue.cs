namespace Day009
{
    internal class CoordinateValue
    {
        public long Row { get; set; }
        public long Column { get; set; }
        public long Value { get; set; }

        public override string ToString()
        {
            return $"{Row}_{Column}_{Value}";
        }
    }
}
