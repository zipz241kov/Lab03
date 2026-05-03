using System.Text.RegularExpressions;

namespace Proxy;

public class SmartTextReaderLocker : ITextReader
{
    private readonly ITextReader _reader;
    private readonly Regex _restrictedRegex;

    public SmartTextReaderLocker(ITextReader reader, string regexPattern)
    {
        _reader = reader;
        _restrictedRegex = new Regex(regexPattern);
    }

    public char[][] ReadText(string filePath)
    {
        if (_restrictedRegex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return new char[0][];
        }
        return _reader.ReadText(filePath);
    }
}
