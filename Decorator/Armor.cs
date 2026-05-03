namespace Decorator;

public class Armor : InventoryDecorator
{
    public Armor(Hero hero) : base(hero) { }
    public override int GetPower() => _hero.GetPower() + 5;
    public override string GetDescription() => _hero.GetDescription() + " + Plate Armor";
}
