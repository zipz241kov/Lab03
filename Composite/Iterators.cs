namespace HTMLCreator;

public interface ILightNodeIterator
{
    bool HasNext();
    LightNode Next();
}

public class DepthFirstIterator : ILightNodeIterator
{
    private Stack<LightNode> _stack = new Stack<LightNode>();

    public DepthFirstIterator(LightNode root) { _stack.Push(root); }

    public bool HasNext() => _stack.Count > 0;

    public LightNode Next()
    {
        var current = _stack.Pop();
        var children = current.GetChildren().ToList();
        for (int i = children.Count - 1; i >= 0; i--)
        {
            _stack.Push(children[i]);
        }
        return current;
    }
}

public class BreadthFirstIterator : ILightNodeIterator
{
    private Queue<LightNode> _queue = new Queue<LightNode>();

    public BreadthFirstIterator(LightNode root) { _queue.Enqueue(root); }

    public bool HasNext() => _queue.Count > 0;

    public LightNode Next()
    {
        var current = _queue.Dequeue();
        foreach (var child in current.GetChildren())
        {
            _queue.Enqueue(child);
        }
        return current;
    }
}