namespace Framework
{
    public class StringFileProcessor : FileProcessor<string>
    {
        public override List<string> GetContent(string path)
        {
            var result = new List<string>();
            var file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line);
            }
            return result;
        }
    }
}
