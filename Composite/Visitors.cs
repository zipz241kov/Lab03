using System.Text;

namespace HTMLCreator;

public interface IVisitor
{
    void Visit(LightElementNode element);
    void Visit(LightTextNode text);
    void Visit(LightImageNode image);
}

public class TextExtractorVisitor : IVisitor
{
    public StringBuilder ExtractedText { get; } = new StringBuilder();

    public void Visit(LightElementNode element)
    {
    }

    public void Visit(LightTextNode text)
    {
        ExtractedText.Append(text.OuterHtml()).Append(" ");
    }

    public void Visit(LightImageNode image)
    {
    }
}