using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Employees
{
    /// <summary>
    /// Перечисление всех должностей
    /// </summary>
    public enum Post
    {
        Manager,
        HR,
        Director
    }

    /// <summary>
    /// Абстрактный класс сотрудника
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Словарь для хранения должностей и их зарплат
        /// </summary>
        protected static Dictionary<Post,int> Posts = new Dictionary<Post, int>
        {
            [Post.Manager] = 10000,
            [Post.HR] = 15000,
            [Post.Director] = 100000,
        };
        /// <summary>
        /// Id сотрудника
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// Дата рожения
        /// </summary>
        public DateTime Birthday { get; private set; }
        /// <summary>
        /// Должность
        /// </summary>
        public Post Post { get; private set; }

        protected Employee(int id, string fullName, DateTime birthday, Post post)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Post = post;
        }

        public abstract double GetSalary();

        public override string ToString()
        {
            return $"Id:{Id}\nFull Name:{FullName}\nBirthday:{Birthday:dd.MM.yyyy}\nSalary:{GetSalary()}";
        }
    }
}
