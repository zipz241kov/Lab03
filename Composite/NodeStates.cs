namespace HTMLCreator;

public interface INodeState
{
    string RenderState(LightElementNode node);
}

public class VisibleState : INodeState
{
    public string RenderState(LightElementNode node)
    {
        return node.GetOriginalOuterHtml();
    }
}

public class HiddenState : INodeState
{
    public string RenderState(LightElementNode node)
    {
        return $"<!-- Прихований елемент: {node.TagName} -->";
    }
}