using Composite;

namespace Flyweight;

public class LightElementNodeOptimized : LightNode
{
    private ElementMetadata _meta;
    private List<LightNode> _children = new List<LightNode>();

    public LightElementNodeOptimized(ElementMetadata meta)
    {
        _meta = meta;
    }

    public void Add(LightNode node) => _children.Add(node);

    public override string InnerHtml() { return "";}

    public override string OuterHtml()
    {
        if (_meta.ClosingType == "single") return $"<{_meta.TagName}>";
        return $"<{_meta.TagName}>...</{_meta.TagName}>";
    }
}
