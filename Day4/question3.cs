using System;
using System.Collections.Generic;

interface INotification
{
    string Status { get; set; }

    void Send(string message);
}

class Email : INotification
{
    public string Status { get; set; }

    public void Send(string message)
    {
        Console.WriteLine("Email Sent : " + message);
        Status = "Success";
    }
}

class SMS : INotification
{
    public string Status { get; set; }

    public void Send(string message)
    {
        Console.WriteLine("SMS Sent : " + message);
        Status = "Success";
    }
}

class WhatsApp : INotification
{
    public string Status { get; set; }

    public void Send(string message)
    {
        Console.WriteLine("WhatsApp Message Sent : " + message);
        Status = "Success";
    }
}

class PushNotification : INotification
{
    public string Status { get; set; }

    public void Send(string message)
    {
        Console.WriteLine("Push Notification Sent : " + message);
        Status = "Success";
    }
}

class NotificationManager
{
    public void Send(string message, params INotification[] notifications)
    {
        foreach (INotification item in notifications)
        {
            item.Send(message);

            Console.WriteLine("Status : " + item.Status);

            Console.WriteLine();
        }
    }
}

class question3
{
    static void Main(string[] args)
    {
        NotificationManager manager = new NotificationManager();

        manager.Send(
            "Welcome to our Application",
            new Email(),
            new WhatsApp(),
            new SMS(),
            new PushNotification()
        );
    }
}