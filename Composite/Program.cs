using HTMLCreator;


var div = new LightElementNode("div", "block", "pair", new List<string> { "container" });

var h1 = new LightElementNode("h1", "block", "pair");
h1.Add(new LightTextNode("Головний заголовок"));

var p = new LightElementNode("p", "block", "pair", new List<string> { "text-muted" });
p.Add(new LightTextNode("Це текстовий абзац"));

var img = new LightImageNode("https://example.com/logo.png");

div.Add(h1);
div.Add(p);
div.Add(img);

Console.WriteLine("\nPR 1: Шаблонний метод");
string renderedHtml = div.Render();


Console.WriteLine("\nPR 2: Ітератор");

Console.WriteLine("Обхід в глибину (DFS)");
ILightNodeIterator dfs = new DepthFirstIterator(div);
while (dfs.HasNext())
{
    var node = dfs.Next();
    if (node is LightElementNode el) Console.WriteLine($"Знайдено тег: <{el.TagName}>");
    else if (node is LightTextNode txt) Console.WriteLine($"Знайдено текст: {txt.OuterHtml()}");
}

Console.WriteLine("\nОбхід в ширину (BFS)");
ILightNodeIterator bfs = new BreadthFirstIterator(div);
while (bfs.HasNext())
{
    var node = bfs.Next();
    if (node is LightElementNode el) Console.WriteLine($"Знайдено тег: <{el.TagName}>");
    else if (node is LightTextNode txt) Console.WriteLine($"Знайдено текст: {txt.OuterHtml()}");
}