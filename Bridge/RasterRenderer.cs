namespace Bridge;

public class RasterRenderer : IRenderer
{
    public void RenderShape(string shapeName) => Console.WriteLine($"Drawing {shapeName} as pixels (Raster)");
}
