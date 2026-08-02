using System;
using System.Collections.Generic;

// Interface
interface IExporter
{
    void Export();
}

// Abstract Class
abstract class Report
{
    public string ReportName { get; set; }

    public abstract void Generate();
}

// PDF Report
class PdfReport : Report, IExporter
{
    public override void Generate()
    {
        Console.WriteLine("PDF Report Generated");
    }

    public void Export()
    {
        Console.WriteLine("PDF Report Exported");
    }
}

// Excel Report
class ExcelReport : Report, IExporter
{
    public override void Generate()
    {
        Console.WriteLine("Excel Report Generated");
    }

    public void Export()
    {
        Console.WriteLine("Excel Report Exported");
    }
}

// CSV Report
class CsvReport : Report, IExporter
{
    public override void Generate()
    {
        Console.WriteLine("CSV Report Generated");
    }

    public void Export()
    {
        Console.WriteLine("CSV Report Exported");
    }
}

// Factory Class
class ReportFactory
{
    public static Report Create(string type)
    {
        if (type == "PDF")
        {
            return new PdfReport();
        }
        else if (type == "Excel")
        {
            return new ExcelReport();
        }
        else if (type == "CSV")
        {
            return new CsvReport();
        }

        return null;
    }
}

// Extension Method
static class ReportExtension
{
    public static void PrintTitle(this Report report)
    {
        Console.WriteLine("------ Report ------");
    }
}

class question9
{
    static void Main(string[] args)
    {
        Report report = ReportFactory.Create("PDF");

        report.PrintTitle();

        report.Generate();

        IExporter exporter = (IExporter)report;

        exporter.Export();

        Console.WriteLine();

        var reportRow = new
        {
            Employee = "Rahul",
            Department = "IT",
            Salary = 50000
        };

        Console.WriteLine("Anonymous Report Row");

        Console.WriteLine("Employee : " + reportRow.Employee);

        Console.WriteLine("Department : " + reportRow.Department);

        Console.WriteLine("Salary : " + reportRow.Salary);
    }
}