using Library.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Класс для сравнения двух сотрудников
    /// </summary>
    public class EmployeeComparer : Comparer<Employee>
    {
        public override int Compare(Employee x, Employee y)
        {
            var tmp1 = x.GetSalary();
            var tmp2 = y.GetSalary();
            if (tmp1 > tmp2)
            {
                return 1;
            }
            else if (tmp1 < tmp2)
            {
                return -1;
            }
            else 
            {
                return string.Compare(x.FullName, y.FullName);
            }
        }
    }
}
