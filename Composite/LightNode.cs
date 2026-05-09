namespace HTMLCreator;

public abstract class LightNode
{
    public string Render()
    {
        OnCreated();
        OnStylesApplied();
        string result = OuterHtml();
        OnTextRendered();
        return result;
    }

    public virtual void OnCreated() { }
    public virtual void OnStylesApplied() { }
    public virtual void OnTextRendered() { }

    public abstract string OuterHtml();
    public abstract string InnerHtml();
}
