using System;
public class LogEntry
{
    public DateTime Timestamp;
    public string Level = "";
    public string Category = "";
    public string Message = "";
}
public class Program
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("event_server.log");
        LogEntry[] entries = ParseLog(lines);
        Console.WriteLine("Всего записей: " + entries.Length);
        Console.WriteLine("Ошибок Error: " + CountByLevel(entries, "Error"));
        Console.WriteLine("Ошибок Fatal: " + CountByLevel(entries, "Fatal"));
        Console.WriteLine(GetServerStatus(entries));
    }
    public static LogEntry[] ParseLog(string[] lines)
    {
        LogEntry[] entries = new LogEntry[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            LogEntry entry = new LogEntry();
            entry.Timestamp = DateTime.Parse(line.Substring(0, 23));
            int firstOpen = line.IndexOf('[');
            int firstClose = line.IndexOf(']', firstOpen);
            entry.Level = line.Substring(firstOpen + 1, firstClose - firstOpen - 1);
            int secondOpen = line.IndexOf('[', firstClose);
            int secondClose = line.IndexOf(']', secondOpen);
            entry.Category = line.Substring(secondOpen + 1, secondClose - secondOpen - 1);
            entry.Message = line.Substring(secondClose + 2);
            entries[i] = entry;
        }
        return entries;
    }
    public static LogEntry[] FilterByDate(LogEntry[] entries, DateTime date)
    {
        LogEntry[] result = new LogEntry[entries.Length];
        int count = 0;
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Timestamp.Date == date.Date)
            {
                result[count] = entries[i];
                count++;
            }
        }
        LogEntry[] answer = new LogEntry[count];
        for (int i = 0; i < count; i++)
        {
            answer[i] = result[i];
        }
        return answer;
    }
    public static LogEntry[] FilterByLevel(LogEntry[] entries, string level)
    {
        LogEntry[] result = new LogEntry[entries.Length];
        int count = 0;
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == level)
            {
                result[count] = entries[i];
                count++;
            }
        }
        LogEntry[] answer = new LogEntry[count];
        for (int i = 0; i < count; i++)
        {
            answer[i] = result[i];
        }
        return answer;
    }
    public static LogEntry[] FilterByCategory(LogEntry[] entries, string category)
    {
        LogEntry[] result = new LogEntry[entries.Length];
        int count = 0;
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Category == category)
            {
                result[count] = entries[i];
                count++;
            }
        }
        LogEntry[] answer = new LogEntry[count];
        for (int i = 0; i < count; i++)
        {
            answer[i] = result[i];
        }
        return answer;
    }
    public static LogEntry[] Search(LogEntry[] entries, string text)
    {
        LogEntry[] result = new LogEntry[entries.Length];
        int count = 0;
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Message.ToLower().Contains(text.ToLower()))
            {
                result[count] = entries[i];
                count++;
            }
        }
        LogEntry[] answer = new LogEntry[count];
        for (int i = 0; i < count; i++)
        {
            answer[i] = result[i];
        }
        return answer;
    }
    public static int CountByLevel(LogEntry[] entries, string level)
    {
        int count = 0;
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == level)
            {
                count++;
            }
        }
        return count;
    }
    public static string GetServerStatus(LogEntry[] entries)
    {
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == "Fatal" && entries[i].Category == "Server")
            {
                return "Критическая ошибка: " + entries[i].Message;
            }
        }
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == "Error")
            {
                return "Есть ошибки: требуется проверка";
            }
        }
        return "Сервер работает штатно";
    }
}