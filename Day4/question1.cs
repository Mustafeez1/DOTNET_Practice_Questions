using System;
using System.Collections.Generic;

abstract class Approver
{
    protected Approver next;

    public void SetNext(Approver nextApprover)
    {
        next = nextApprover;
    }

    public abstract void ApproveRequest(double amount);
}

class TeamLead : Approver
{
    public override void ApproveRequest(double amount)
    {
        if (amount <= 10000)
        {
            Console.WriteLine("Team Lead Approved : ₹" + amount);
        }
        else if (next != null)
        {
            next.ApproveRequest(amount);
        }
    }
}

class Manager : Approver
{
    public override void ApproveRequest(double amount)
    {
        if (amount <= 50000)
        {
            Console.WriteLine("Manager Approved : ₹" + amount);
        }
        else if (next != null)
        {
            next.ApproveRequest(amount);
        }
    }
}

class Director : Approver
{
    public override void ApproveRequest(double amount)
    {
        Console.WriteLine("Director Approved : ₹" + amount);
    }
}

class question1
{
    static void Main(string[] args)
    {
        TeamLead teamLead = new TeamLead();
        Manager manager = new Manager();
        Director director = new Director();

        teamLead.SetNext(manager);
        manager.SetNext(director);

        List<double> requests = new List<double>()
        {
            5000,
            15000,
            30000,
            70000,
            100000
        };

        foreach (double amount in requests)
        {
            teamLead.ApproveRequest(amount);
        }
    }
}