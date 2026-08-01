using System;
class p7
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the name");
        string empname= Console.ReadLine();

        int hoursWorked;
        while(!int.TryParse(Console.ReadLine(), hoursWorked) || hoursWorked < 0)
        {
            Console.WriteLine("Invalid hours worked enter a positive number");
            Console.WriteLine("Enter again");
        }

        double hourlyRate;
        while(!double.TryParse(Console.ReadLine(), hourlyRate) || hourlyRate < 0)
        {
            Console.WriteLine("Invalid hourlyrate  enter a positive number");
            Console.WriteLine("Enter again");
        }

        Employee employee = new Employee(name, hoursWorked, hourlyRate);

        PayrollCalculator payroll = new PayrollCalculator();
        double regularPay = payroll.CalculateRegularPay(employee);
        double overtimePay = payroll.CalculateOvertimePay(employee);
        double grossSalary = payroll.CalculateGrossSalary(employee);

        Console.WriteLine($"Employee Name : {employee.Name}");
        Console.WriteLine($"Hours Worked  : {employee.HoursWorked}");
        Console.WriteLine($"Hourly Rate   : ₹{employee.HourlyRate}");
        Console.WriteLine($"Regular Pay   : ₹{Math.Round(regularPay, 2)}");
        Console.WriteLine($"Overtime Pay  : ₹{Math.Round(overtimePay, 2)}");
        Console.WriteLine($"Gross Salary  : ₹{Math.Round(grossSalary, 2)}");
    }
}
class Employee
{
    public string Name { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public Employee(string name, double hoursWorked, double hourlyRate)
    {
        Name = name;
        HoursWorked = hoursWorked;
        HourlyRate = hourlyRate;
    }
}
class PayrollCalculator()
{
    public double CalculateRegularPay(Employee employee)
    {
        double regularHours = Math.Min(employee.HoursWorked, 40);
        return regularHours * employee.HourlyRate;
    }

    public double CalculateOvertimePay(Employee employee)
    {
        if (employee.HoursWorked > 40)
        {
            double overtimeHours = employee.HoursWorked - 40;
            return overtimeHours * employee.HourlyRate * 1.5;
        }

        return 0;
    }

    public double CalculateGrossSalary(Employee employee)
    {
        return CalculateRegularPay(employee) + CalculateOvertimePay(employee);
    }
}