using System;

enum LogLevel
{
    INFO,
    WARNING,
    ERROR
}
class problem3
{
    static void ParseLogLine(
        in string logLine,
        out DateTime timestamp,
        out LogLevel level,
        ref int counter)
    {
        string[] parts = logLine.Split(' ');

        timestamp = DateTime.Parse(parts[0] + " " + parts[1]);

        level = Enum.Parse<LogLevel>(parts[2].Replace(":", ""));

        counter++;
    }

    static void Main()
    {
        string log = "2023-10-27 14:30:00 ERROR: Disk full";

        int totalLines = 0;

        ParseLogLine(
            in log,
            out DateTime time,
            out LogLevel logLevel,
            ref totalLines);

        Console.WriteLine("Timestamp : " + time);

        Console.WriteLine("Log Level : " + logLevel);

        Console.WriteLine("Lines Processed : " + totalLines);
    }
}