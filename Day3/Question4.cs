class Employee
{
    private double salary;

    public double Salary
    {
        get { return salary; }
    }

    public void IncreaseSalary(double amount)
    {
        if (amount > 0)
        {
            salary += amount;
        }
    }
}