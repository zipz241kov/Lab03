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


// Template
Console.WriteLine("\nPR 1: Шаблонний метод");
string renderedHtml = div.Render();


// Iterator
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


// Command
Console.WriteLine("\nPR 3: Команда");
var commandManager = new CommandManager();

Console.WriteLine($"До виконання команди: \n{p.GetOriginalOuterHtml()}");

var addHighlight = new AddClassCommand(p, "highlight");
commandManager.ExecuteCommand(addHighlight);
Console.WriteLine($"Після додавання класу: \n{p.GetOriginalOuterHtml()}");

commandManager.UndoLast();
Console.WriteLine($"Після Undo: \n{p.GetOriginalOuterHtml()}");


// State
Console.WriteLine("\nPR 4: Стан (State)");

Console.WriteLine($"Звичайний стан h1:\n{h1.OuterHtml()}");

h1.State = new HiddenState();
Console.WriteLine($"Прихованийстан h1:\n{h1.OuterHtml()}");

h1.State = new VisibleState();