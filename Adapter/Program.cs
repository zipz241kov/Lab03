using Adapter;

Console.WriteLine("--- Завдання 1: Адаптер ---");
ILogger consoleLogger = new ConsoleLogger();
consoleLogger.Log("Це звичайне повідомлення");
consoleLogger.Error("Це помилка!");

FileWriter writer = new FileWriter();
ILogger fileLogger = new FileLoggerAdapter(writer);
fileLogger.Warn("Це попередження записано у файл log.txt");
Console.WriteLine("Запис у файл завершено.\n");