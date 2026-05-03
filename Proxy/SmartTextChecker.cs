namespace Proxy;

public class SmartTextChecker : ITextReader
{
    private readonly ITextReader _reader;

    public SmartTextChecker(ITextReader reader) { _reader = reader; }

    public char[][] ReadText(string filePath)
    {
        Console.WriteLine($"[Log]: Opening file {filePath}");
        char[][] result = _reader.ReadText(filePath);
        Console.WriteLine($"[Log]: File read successfully. Lines: {result.Length}");

        int totalChars = 0;
        foreach (var line in result) totalChars += line.Length;
        Console.WriteLine($"[Log]: Total characters: {totalChars}");
        Console.WriteLine($"[Log]: Closing file {filePath}");

        return result;
    }
}
