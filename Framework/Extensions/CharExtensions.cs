namespace Framework.Extensions
{
    public static class CharExtensions
    {
        public static int ToInt(this char input)
        {
            return Convert.ToInt32(input);
        }
        public static byte ToByte(this char input)
        {
            return Convert.ToByte(input);
        }
        public static long ToLong(this char input)
        {
            return Convert.ToInt64(Convert.ToString(input));
        }
    }
}
