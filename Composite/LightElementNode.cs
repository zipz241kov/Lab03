using System.Text;

namespace Composite;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }
    public List<string> CssClasses { get; }
    private List<LightNode> _children = new List<LightNode>();

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses = null)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
        CssClasses = cssClasses ?? new List<string>();
    }

    public void Add(LightNode node) => _children.Add(node);

    public override string InnerHtml()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var child in _children) sb.Append(child.OuterHtml());
        return sb.ToString();
    }

    public override string OuterHtml()
    {
        string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
        string openTag = $"<{TagName}{classes}>";

        if (ClosingType == "single") return openTag;
        return $"{openTag}{InnerHtml()}</{TagName}>";
    }
}
