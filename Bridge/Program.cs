using Bridge;


Console.WriteLine("--- Завдання 3: Міст ---");
IRenderer raster = new RasterRenderer();
IRenderer vector = new VectorRenderer();

Shape triangle1 = new Triangle(raster);
Shape triangle2 = new Triangle(vector);

triangle1.Draw();
triangle2.Draw();
Console.WriteLine();
