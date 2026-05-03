namespace Composite;

public class NetworkLoadStrategy : IImageLoadStrategy
{
    public void Load(string href)
    {
        Console.WriteLine($"Downloading image from network: {href}");
    }
}
