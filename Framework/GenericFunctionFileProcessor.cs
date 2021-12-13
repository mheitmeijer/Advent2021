namespace Framework
{
    public class GenericFunctionFileProcessor<T>
    {
        public List<T> GetContent(string path, Func<string, T> converter)
        {
            var result = new List<T>();
            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(converter(line));
            }
            return result;
        }
        public List<T> GetContentSingleLine(string path, Func<string, List<T>> converter)
        {
            var result = new List<T>();
            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                result.AddRange(converter(line));
            }
            return result;
        }
    }
}
