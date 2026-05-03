namespace Flyweight;

public class ElementMetadata
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }

    public ElementMetadata(string tag, string display, string closing)
    {
        TagName = tag; DisplayType = display; ClosingType = closing;
    }
}
