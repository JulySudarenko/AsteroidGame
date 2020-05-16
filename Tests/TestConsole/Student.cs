﻿using System;
using System.Collections.Generic;
using TestConsole.Loggers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    #region Student + Logger Lesson 2 Интерфейс
    //internal class Student : ILogger
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public string Patronimyc { get; set; }

    //    public int GroupId { get; set; }

    //    public void Log(string Message)
    //    {
    //        Console.WriteLine("Студент {0} пишет в журнал: {1}", Name, Message); ;
    //    }
    //}
    #endregion

    interface IEntity
    {
        int Id { get; set; }
    }

    internal class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>, IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int GroupId { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        public double AverageRating
        {
            get
            {
                var result = 0d;
                foreach (var rating in Ratings)
                    result += rating;
                return result / Ratings.Count;
            }
        }

        public int CompareTo(Student other)
        {
            var current_average_rating = AverageRating;
            var other_average_rating = other.AverageRating;

            if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
                return 0;
            if (current_average_rating > other_average_rating)
                return +1;
            else
                return -1;
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;

            //if (Name == other.Name && Surname == other.Surname && other.Patronimyc == Patronimyc)
            //    return true;
            //return false;

            return Name == other.Name && Surname == other.Surname && other.Patronymic == Patronymic;
        }

        public bool Equals(string other)
        {
            if (other is null) return false;

            return Name == other || Surname == other || Patronymic == other;
        }
    }
}



