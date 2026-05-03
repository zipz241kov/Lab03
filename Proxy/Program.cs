using Proxy;

Console.WriteLine("--- Завдання 4: Проксі ---");
File.WriteAllText("test.txt", "Hello\nWorld!");
File.WriteAllText("secret.dat", "Top Secret");

ITextReader baseReader = new SmartTextReader();
ITextReader loggedReader = new SmartTextChecker(baseReader);
ITextReader lockedReader = new SmartTextReaderLocker(loggedReader, @"\.dat$");

Console.WriteLine("Reading text.txt:");
lockedReader.ReadText("test.txt");

Console.WriteLine("Reading secret.dat:");
lockedReader.ReadText("secret.dat");
Console.WriteLine();