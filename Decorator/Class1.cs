namespace Decorator;

public abstract class Hero
{
    public string Name { get; protected set; }
    public abstract int GetPower();
    public abstract string GetDescription();
}
