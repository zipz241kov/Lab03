namespace Adapter;

public class FileWriter
{
    public void Write(string text) => File.AppendAllText("log.txt", text);
    public void WriteLine(string text) => File.AppendAllText("log.txt", text + Environment.NewLine);
}
