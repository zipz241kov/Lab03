namespace Bridge;

public class VectorRenderer : IRenderer
{
    public void RenderShape(string shapeName) => Console.WriteLine($"Drawing {shapeName} as lines (Vector)");
}
