using Flyweight;
using Composite;

Console.WriteLine("--- Завдання 6: Легковаговик (Текст з Gutenberg) ---");

string bookUrl = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
string[] lines;
using (var client = new HttpClient())
{
    Console.WriteLine("Завантаження книги...");
    string fullText = await client.GetStringAsync(bookUrl);
    lines = fullText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
}
Console.WriteLine($"Завантажено {lines.Length} рядків.");

GC.Collect();
GC.WaitForPendingFinalizers();
long memBefore = GC.GetTotalMemory(true);

var unoptimizedNodes = new List<LightElementNode>();
for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    string tag = "p";
    if (i == 0) tag = "h1";
    else if (line.Length < 20) tag = "h2";
    else if (line.StartsWith(" ")) tag = "blockquote";

    var node = new LightElementNode(tag, "block", "pair", new List<string>());
    node.Add(new LightTextNode(line));
    unoptimizedNodes.Add(node);
}

long memAfter = GC.GetTotalMemory(true);
Console.WriteLine($"Пам'ять БЕЗ Легковаговика: {(memAfter - memBefore) / 1024} KB");

unoptimizedNodes = null;
GC.Collect();

long memBeforeFly = GC.GetTotalMemory(true);

var factory = new FlyweightFactory();
var h1Meta = factory.GetMetadata("h1", "block", "pair");
var h2Meta = factory.GetMetadata("h2", "block", "pair");
var blockquoteMeta = factory.GetMetadata("blockquote", "block", "pair");
var pMeta = factory.GetMetadata("p", "block", "pair");

var optimizedNodes = new List<LightElementNodeOptimized>();
for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    ElementMetadata meta = pMeta;
    if (i == 0) meta = h1Meta;
    else if (line.Length < 20) meta = h2Meta;
    else if (line.StartsWith(" ")) meta = blockquoteMeta;

    var node = new LightElementNodeOptimized(meta);
    node.Add(new LightTextNode(line));
    optimizedNodes.Add(node);
}

long memAfterFly = GC.GetTotalMemory(true);
Console.WriteLine($"Пам'ять З Легковаговиком:  {(memAfterFly - memBeforeFly) / 1024} KB");
Console.WriteLine($"Економія: {((memAfter - memBefore) - (memAfterFly - memBeforeFly)) / 1024} KB\n");
