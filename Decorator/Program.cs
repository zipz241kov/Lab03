using Decorator;

Console.WriteLine("--- Завдання 2: Декоратор ---");
Hero myHero = new Warrior();
Console.WriteLine($"{myHero.GetDescription()} | Power: {myHero.GetPower()}");

myHero = new Weapon(myHero);
myHero = new Armor(myHero);
myHero = new Weapon(myHero);

Console.WriteLine($"{myHero.GetDescription()} | Power: {myHero.GetPower()}\n");
