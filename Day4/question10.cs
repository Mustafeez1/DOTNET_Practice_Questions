using System;

namespace Plugins
{
    public interface IPlugin
    {
        void Execute();
    }

    public class TaxPlugin : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Tax Plugin Executed");
        }
    }

    public class PaymentPlugin : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Payment Plugin Executed");
        }
    }

    public class LoggingPlugin : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Logging Plugin Executed");
        }
    }

    public class PluginLoader<T> where T : IPlugin, new()
    {
        public void Load()
        {
            T plugin = new T();

            Console.WriteLine("Loading Plugin...");

            plugin.Execute();

            Console.WriteLine("Plugin Loaded Successfully");
        }
    }
}

class question10
{
    static void Main(string[] args)
    {
        Plugins.PluginLoader<Plugins.TaxPlugin> tax =
            new Plugins.PluginLoader<Plugins.TaxPlugin>();

        tax.Load();

        Console.WriteLine();

        Plugins.PluginLoader<Plugins.PaymentPlugin> payment =
            new Plugins.PluginLoader<Plugins.PaymentPlugin>();

        payment.Load();

        Console.WriteLine();

        Plugins.PluginLoader<Plugins.LoggingPlugin> log =
            new Plugins.PluginLoader<Plugins.LoggingPlugin>();

        log.Load();
    }
}