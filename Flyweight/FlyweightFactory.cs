namespace Flyweight;

public class FlyweightFactory
{
    private Dictionary<string, ElementMetadata> _pool = new Dictionary<string, ElementMetadata>();

    public ElementMetadata GetMetadata(string tag, string display, string closing)
    {
        string key = $"{tag}_{display}_{closing}";
        if (!_pool.ContainsKey(key))
        {
            _pool[key] = new ElementMetadata(tag, display, closing);
        }
        return _pool[key];
    }
}
