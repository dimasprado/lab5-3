using Library;
using Library.Employees;
using System;
using System.Collections.Generic;

namespace lab3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем много сотрудников
            var list = new List<Employee>
            {
                new FixedSalary(1,"B S D", new DateTime(DateTime.Now.Ticks),Post.HR),
                new FixedSalary(0,"A S D", new DateTime(DateTime.Now.Ticks),Post.Manager),
                new FixedSalary(2,"C S D", new DateTime(DateTime.Now.Ticks),Post.Director),
                new HourlyPay(4,"A S D", new DateTime(DateTime.Now.Ticks),Post.Manager, 1000),
                new HourlyPay(5,"B S D", new DateTime(DateTime.Now.Ticks),Post.Manager, 1000),
                new HourlyPay(3,"C S D", new DateTime(DateTime.Now.Ticks),Post.Manager, 1000),
                new HourlyPay(6,"D D D", new DateTime(DateTime.Now.Ticks),Post.Manager, 1000),
            };
            var org = new Organization();

            // Добавляем их в организацию
            org.AddEmployee(list); 

            // Записываем организацию в файл
            org.SaveInFile("file.json");
            // Работаем со считанной из файла организацией
            org = Organization.ReadFromFile("file.json");
            org.Sort(new EmployeeComparer());
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(org[i].FullName);
            }
            for (int i = org.Count - 1; i >= org.Count-4; i--)
            {
                Console.WriteLine(org[i].Id);
            }
            for (int i = 0; i < org.Count; i++)
            {
                Console.WriteLine(org[i]);
                Console.WriteLine();
            }
        }
    }
}
