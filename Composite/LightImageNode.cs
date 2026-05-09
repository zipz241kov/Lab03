namespace HTMLCreator;

public class LightImageNode: LightNode
{
    public string Href { get; }
    private IImageLoadStrategy _loadStrategy;

    public LightImageNode(string href)
    {
        Href = href;

        if (href.StartsWith("http://") || href.StartsWith("https://"))
        {
            _loadStrategy = new NetworkLoadStrategy();
        }
        else
        {
            _loadStrategy = new FileSystemLoadStrategy();
        }
    }

    public string Render()
    {
        _loadStrategy.Load(Href);
        return $"<img src=\"{Href}\" />";
    }

    public override string OuterHtml() => Render();

    public override string InnerHtml() => Render();
}
