namespace Decorator;

public class Weapon : InventoryDecorator
{
    public Weapon(Hero hero) : base(hero) { }
    public override int GetPower() => _hero.GetPower() + 15;
    public override string GetDescription() => _hero.GetDescription() + " + Sword";
}
