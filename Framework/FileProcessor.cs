namespace Framework
{
    public abstract class FileProcessor<T>
    {
        public abstract List<T> GetContent(string filePath);
    }
}