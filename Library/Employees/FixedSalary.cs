using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Employees
{
    /// <summary>
    /// Сотрудник с фиксированной платой за месяц
    /// </summary>
    public class FixedSalary : Employee
    {
        public FixedSalary(int id, string fullName, DateTime birthday, Post post) 
            : base(id, fullName, birthday, post)
        {
        }

        /// <summary>
        /// Плата за месяц
        /// </summary>
        public double Salary {
            get {
                return Posts[Post];
            }
        }

        public override double GetSalary()
        {
            return Salary;
        }
    }
}
