using System;

abstract class Employee
{
    private int id;
    private string name;

    public int Id
    {
        get { return id; }
        set
        {
            if (value > 0)
                id = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                name = value;
        }
    }

    public abstract double CalculateSalary();

    public abstract double CalculateBonus();
}

class PermanentEmployee : Employee
{
    public double BasicSalary { get; set; }

    public override double CalculateSalary()
    {
        return BasicSalary;
    }

    public override double CalculateBonus()
    {
        return BasicSalary * 0.20;
    }
}

class ContractEmployee : Employee
{
    public double Salary { get; set; }

    public override double CalculateSalary()
    {
        return Salary;
    }

    public override double CalculateBonus()
    {
        return Salary * 0.10;
    }
}

class Intern : Employee
{
    public double Stipend { get; set; }

    public override double CalculateSalary()
    {
        return Stipend;
    }

    public override double CalculateBonus()
    {
        return 0;
    }
}

class question4
{
    static void Main(string[] args)
    {
        PermanentEmployee emp1 = new PermanentEmployee
        {
            Id = 1,
            Name = "Rahul",
            BasicSalary = 50000
        };

        ContractEmployee emp2 = new ContractEmployee
        {
            Id = 2,
            Name = "Amit",
            Salary = 30000
        };

        Intern emp3 = new Intern
        {
            Id = 3,
            Name = "Neha",
            Stipend = 15000
        };

        var report = new
        {
            PermanentSalary = emp1.CalculateSalary(),
            PermanentBonus = emp1.CalculateBonus(),

            ContractSalary = emp2.CalculateSalary(),
            ContractBonus = emp2.CalculateBonus(),

            InternSalary = emp3.CalculateSalary(),
            InternBonus = emp3.CalculateBonus()
        };

        Console.WriteLine("Payroll Report");
        Console.WriteLine();

        Console.WriteLine("Permanent Employee");
        Console.WriteLine("Salary : " + report.PermanentSalary);
        Console.WriteLine("Bonus  : " + report.PermanentBonus);

        Console.WriteLine();

        Console.WriteLine("Contract Employee");
        Console.WriteLine("Salary : " + report.ContractSalary);
        Console.WriteLine("Bonus  : " + report.ContractBonus);

        Console.WriteLine();

        Console.WriteLine("Intern");
        Console.WriteLine("Salary : " + report.InternSalary);
        Console.WriteLine("Bonus  : " + report.InternBonus);
    }
}