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

li2.AddEventListener("click", () => Console.WriteLine("Обробник 1"));
li2.AddEventListener("click", () => Console.WriteLine("Обробник 2"));
li2.AddEventListener("mouseover", () => Console.WriteLine("Обробник: Курсор наведено на кнопку."));

li2.DispatchEvent("click");
li2.DispatchEvent("mouseover");

Console.WriteLine("\n--- Завдання 4: Стратегія ---");

var img1 = new LightImageNode("https://example.com/cats.png");
Console.WriteLine(img1.Render());

Console.WriteLine();

var img2 = new LightImageNode("C:/images/dogs.jpg");
Console.WriteLine(img2.Render());
