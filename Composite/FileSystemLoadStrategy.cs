namespace Composite;

public class FileSystemLoadStrategy : IImageLoadStrategy
{
    public void Load(string href)
    {
        Console.WriteLine($"Loading image from local file system: {href}");
    }
}
