using system;
class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Temperature { get; set; }

    public double CalculateBMI()
    {
        return Weight / (Height * Height);
    }
}

class Validation
{
    public static int ReadPositiveInt(string message)
    {
        int value;

        Console.Write(message);

        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            Console.Write(message);
        }

        return value;
    }

    public static double ReadPositiveDouble(string message)
    {
        double value;

        Console.Write(message);

        while (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            Console.Write(message);
        }

        return value;
    }
}
class p9
{
    public static void Main(string[] args)
    {
        Patient patient = new Patient();

        Console.Write("Enter Patient Name: ");
        patient.Name = Console.ReadLine();

        patient.Age = Validation.ReadPositiveInt("Enter Age: ");

        patient.Weight = Validation.ReadPositiveDouble("Enter Weight (kg): ");

        patient.Height = Validation.ReadPositiveDouble("Enter Height (m): ");

        patient.Temperature = Validation.ReadPositiveDouble("Enter Body Temperature (°C): ");



        Console.WriteLine($"Name         : {patient.Name}");
        Console.WriteLine($"Age          : {patient.Age} years");
        Console.WriteLine($"Weight       : {patient.Weight} kg");
        Console.WriteLine($"Height       : {patient.Height} m");
        Console.WriteLine($"Temperature  : {patient.Temperature} °C");
        Console.WriteLine($"BMI          : {Math.Round(patient.CalculateBMI(), 2)}");
    }
}