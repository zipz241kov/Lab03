namespace Adapter;

public class ConsoleLogger : ILogger
{
    public void Log(string message) { Print(message, ConsoleColor.Green); }
    public void Error(string message) { Print(message, ConsoleColor.Red); }
    public void Warn(string message) { Print(message, ConsoleColor.DarkYellow); }

    private void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
