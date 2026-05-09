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
