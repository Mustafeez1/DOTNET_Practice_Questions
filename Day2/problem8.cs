using System;

class problem8
{
    static string FormatLogMessage(string message, params object[] values)
    {
        string result = message;

        void ReplaceValues()
        {
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i].ToString();

                int number;

                if (int.TryParse(value, out number))
                {
                    value = number.ToString();
                }

                result = result.Replace("{" + i + "}", value);
            }
        }

        ReplaceValues();

        return result;
    }

    static void Main(string[] args)
    {
        string message = "User {0} logged in from {1} at {2}";

        string output = FormatLogMessage(
            message,
            "JohnDoe",
            "192.168.1.1",
            DateTime.Now
        );

        Console.WriteLine(output);
    }
}