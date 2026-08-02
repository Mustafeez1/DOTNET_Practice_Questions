using System;
using System.Collections.Generic;

namespace MiniORM
{
    // Partial Class - Part 1
    public partial class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    // Partial Class - Part 2
    public partial class Employee
    {
        public void Display()
        {
            Console.WriteLine(Id + " " + Name);
        }
    }

    class Database
    {
        private Dictionary<Type, List<object>> tables = new Dictionary<Type, List<object>>();

        // Save
        public void Save<T>(T obj)
        {
            Type type = typeof(T);

            if (!tables.ContainsKey(type))
            {
                tables[type] = new List<object>();
            }

            tables[type].Add(obj);

            Console.WriteLine(type.Name + " Saved");
        }

        // Get
        public T Get<T>(int id) where T : Employee
        {
            Type type = typeof(T);

            if (tables.ContainsKey(type))
            {
                foreach (object item in tables[type])
                {
                    T emp = (T)item;

                    if (emp.Id == id)
                    {
                        return emp;
                    }
                }
            }

            return null;
        }

        // Delete
        public void Delete<T>(int id) where T : Employee
        {
            Type type = typeof(T);

            if (tables.ContainsKey(type))
            {
                foreach (object item in tables[type])
                {
                    T emp = (T)item;

                    if (emp.Id == id)
                    {
                        tables[type].Remove(item);

                        Console.WriteLine(type.Name + " Deleted");

                        return;
                    }
                }
            }

            Console.WriteLine("Record Not Found");
        }

        // Get All
        public List<T> GetAll<T>() where T : Employee
        {
            List<T> list = new List<T>();

            Type type = typeof(T);

            if (tables.ContainsKey(type))
            {
                foreach (object item in tables[type])
                {
                    list.Add((T)item);
                }
            }

            return list;
        }
    }

    class question8
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            Employee emp1 = new Employee
            {
                Id = 1,
                Name = "Rahul"
            };

            Employee emp2 = new Employee
            {
                Id = 2,
                Name = "Amit"
            };

            db.Save(emp1);
            db.Save(emp2);

            Console.WriteLine();

            Employee e = db.Get<Employee>(1);

            if (e != null)
            {
                Console.WriteLine("Employee Found");
                e.Display();
            }

            Console.WriteLine();

            Console.WriteLine("All Employees");

            List<Employee> employees = db.GetAll<Employee>();

            foreach (Employee emp in employees)
            {
                emp.Display();
            }

            Console.WriteLine();

            db.Delete<Employee>(2);

            Console.WriteLine();

            Console.WriteLine("Employees After Delete");

            employees = db.GetAll<Employee>();

            foreach (Employee emp in employees)
            {
                emp.Display();
            }
        }
    }
}