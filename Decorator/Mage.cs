namespace Decorator;

public class Mage : Hero
{
    public Mage() { Name = "Mage"; }
    public override int GetPower() => 8;
    public override string GetDescription() => Name;
}
