using System.Text;

namespace HTMLCreator;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }
    public List<string> CssClasses { get; }
    private List<LightNode> _children = new List<LightNode>();

    private Dictionary<string, List<Action>> _eventListeners = new Dictionary<string, List<Action>>();

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
        return State.RenderState(this);
    }

    public string GetOriginalOuterHtml()
    {
        string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
        string openTag = $"<{TagName}{classes}>";

        if (ClosingType == "single") return openTag;
        return $"{openTag}{InnerHtml()}</{TagName}>";
    }

    public void AddEventListener(string eventType, Action listener)
    {
        if (!_eventListeners.ContainsKey(eventType))
        {
            _eventListeners[eventType] = new List<Action>();
        }
        _eventListeners[eventType].Add(listener);
    }


    public void DispatchEvent(string eventType)
    {
        if (_eventListeners.ContainsKey(eventType))
        {
            Console.WriteLine($"\n--- Triggering event: {eventType} on <{TagName}> ---");
            foreach (var listener in _eventListeners[eventType])
            {
                listener.Invoke();
            }
        }
    }

    public override void OnCreated() => Console.WriteLine($"[Hook] Вузол <{TagName}> створено.");
    public override void OnStylesApplied() => Console.WriteLine($"[Hook] Стилі застосовано до <{TagName}>.");
    public override void OnTextRendered() => Console.WriteLine($"[Hook] Рендеринг <{TagName}> завершено.");

    public override IEnumerable<LightNode> GetChildren() => _children;

    public INodeState State { get; set; } = new VisibleState();

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var child in _children)
        {
            child.Accept(visitor);
        }
    }
}
