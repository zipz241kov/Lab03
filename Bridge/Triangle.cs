namespace Bridge;

public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer) { }
    public override void Draw() => _renderer.RenderShape("Triangle");
}
