namespace Decorator;

public class Warrior : Hero
{
    public Warrior() { Name = "Warrior"; }
    public override int GetPower() => 10;
    public override string GetDescription() => Name;
}
