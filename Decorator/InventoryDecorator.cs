namespace Decorator;

public abstract class InventoryDecorator : Hero
{
    protected Hero _hero;
    public InventoryDecorator(Hero hero) { _hero = hero; }
}
