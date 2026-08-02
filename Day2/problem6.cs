using System;

interface IConfigurationSource
{
    bool TryLoad(out string data);
}

class EnvironmentSource : IConfigurationSource
{
    public bool TryLoad(out string data)
    {
        data = "";
        return false;
    }
}

class JsonFileSource : IConfigurationSource
{
    public bool TryLoad(out string data)
    {
        data = "";
        return false;
    }
}

class DatabaseSource : IConfigurationSource
{
    public bool TryLoad(out string data)
    {
        data = "Server=SQL;Database=EmployeeDB";
        return true;
    }
}

static class ConfigurationLoader
{
    public static bool Load(out string config, params IConfigurationSource[] sources)
    {
        config = "";

        foreach (IConfigurationSource source in sources)
        {
            if (source.TryLoad(out config))
            {
                Console.WriteLine("Configuration Loaded Successfully");
                Console.WriteLine("Loaded From : " + source.GetType().Name);
                return true;
            }
        }

        Console.WriteLine("Configuration Not Found");
        return false;
    }
}

class problem6
{
    static void Main(string[] args)
    {
        string config;

        ConfigurationLoader.Load(
            out config,
            new EnvironmentSource(),
            new JsonFileSource(),
            new DatabaseSource()
        );

        Console.WriteLine("Configuration Data");
        Console.WriteLine(config);
    }
}