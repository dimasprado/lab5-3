using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Employees
{
    /// <summary>
    /// Класс работника с почасовой оплатой
    /// </summary>
    public class HourlyPay : Employee
    {
        public HourlyPay(int id, string fullName, DateTime birthday, Post post, double paymentPerHour)
            : base(id, fullName, birthday, post)
        {
            PaymentPerHour = paymentPerHour;
        }

        /// <summary>
        /// Зарплата за час
        /// </summary>
        public double PaymentPerHour { get; private set; }

        public override double GetSalary()
        {
            return PaymentPerHour * 8 * 20;
        }
    }
}
