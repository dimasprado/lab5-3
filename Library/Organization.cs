using Library.Employees;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class Organization
    {
        /// <summary>
        /// Список всех сотрудников
        /// </summary>
        private readonly List<Employee> Employees = new List<Employee>();

        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public int Count
        {
            get
            {
                return Employees.Count;
            }
        }

        /// <summary>
        /// Общая зарплата всех сотрудников
        /// </summary>
        public double TotalSalary { get; private set; } = 0;

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public void AddEmployee(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            Employees.Add(employee);
            TotalSalary += employee.GetSalary();
        }

        /// <summary>
        /// Добавление нескольких сотрудников
        /// </summary>
        /// <param name="employees">Коллекция сотрудников</param>
        public void AddEmployee(IEnumerable<Employee> employees)
        {
            if (employees is null)
            {
                throw new ArgumentNullException(nameof(employees));
            }
            foreach(var employee in employees)
            {
                Employees.Add(employee);
                TotalSalary += employee.GetSalary();
            }            
        }

        /// <summary>
        /// Индексатор для более лекгой работой с отсортированными сотрудникам
        /// </summary>
        /// <param name="index">Индекс сотрудника в отсортированном списке</param>
        /// <returns>Сотрудника с позицией index в списке</returns>
        public Employee this[int index]
        {
            get
            {
                return Employees[index];
            }
        }

        /// <summary>
        /// Сортировка сотрудников
        /// </summary>
        /// <param name="comparer">Объект класса для сравнения сотрудников</param>
        public void Sort(IComparer<Employee> comparer)
        {
            if(comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            Employees.Sort(comparer);
        }

        /// <summary>
        /// Сохранение организации в файл json
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void SaveInFile(string filename)
        {
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Include,
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            using (StreamWriter sw = new StreamWriter(filename))
            {
                serializer.Serialize(sw, Employees);
            }
        }

        /// <summary>
        /// Загрузка организации из файла json
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Объект организации считанный из файла json</returns>
        public static Organization ReadFromFile(string filename)
        {
            try
            {
                var serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Include,
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                };

                List<Employee> tmp;

                using (var sr = new JsonTextReader(new StreamReader(filename)))
                {
                    tmp = serializer.Deserialize<List<Employee>>(sr);
                }

                var org = new Organization();
                org.AddEmployee(tmp);
                return org;
            }
            catch (Exception)
            {

                throw new Exception("Неверный формат файла");
            }
        }

    }
}
