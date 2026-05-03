namespace Decorator;

public class Paladin : Hero
{
    public Paladin() { Name = "Paladin"; }
    public override int GetPower() => 12;
    public override string GetDescription() => Name;
}
