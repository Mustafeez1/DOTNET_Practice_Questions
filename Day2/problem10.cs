using System;
using System.Collections.Generic;

class QueryBuilder
{
    static List<string> conditions = new List<string>();

    // Method 1
    public static void AddWhereClause(string condition)
    {
        conditions.Add(condition);
    }

    // Method 2 (Overloading)
    public static void AddWhereClause(params string[] values)
    {
        foreach (string item in values)
        {
            conditions.Add(item);
        }
    }

    public static void DisplayQuery()
    {
        int level = 0;

        void PrintCondition(int index, ref int level)
        {
            if (index >= conditions.Count)
            {
                return;
            }

            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }

            if (index == 0)
            {
                Console.WriteLine("WHERE " + conditions[index]);
            }
            else
            {
                Console.WriteLine("AND " + conditions[index]);
            }

            level++;

            PrintCondition(index + 1, ref level);

            level--;
        }

        PrintCondition(0, ref level);
    }
}

class Problem10
{
    static void Main(string[] args)
    {
        QueryBuilder.AddWhereClause("Status = 'Active'");

        QueryBuilder.AddWhereClause(
            "Age > 18",
            "Age < 65",
            "Salary > 50000"
        );

        Console.WriteLine("Generated SQL Query");

        QueryBuilder.DisplayQuery();
    }
}