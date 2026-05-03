using Composite;


Console.WriteLine("--- Завдання 5: Компонувальник ---");
var ul = new LightElementNode("ul", "block", "pair", new List<string> { "my-list" });
var li1 = new LightElementNode("li", "block", "pair");
li1.Add(new LightTextNode("Пункт 1"));
var li2 = new LightElementNode("li", "block", "pair");
li2.Add(new LightTextNode("Пункт 2"));

ul.Add(li1);
ul.Add(li2);

Console.WriteLine(ul.OuterHtml());
Console.WriteLine();
