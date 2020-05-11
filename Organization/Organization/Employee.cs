using System;
using System.IO;
using System.Collections.Generic;


//July Sudarenko

namespace Organization
{
    public class Employee : IComparable<Employee>, IEquatable<string>, IEquatable<Employee>
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public double Salary { get; set; }
        public int IdDepartment { get; set; }

        public Employee(string Surname, string Name, string Patronymic)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
        }

        public Employee()
        {
        }

        public static string NameDepForEmployee(Employee employee, Department department)
        {
            if (employee.IdDepartment == department.Id)
                return $"{department.NameDep}";
            return null;
        }

        public int CompareTo(Employee other)
        {
            if (other is null) return 1;
            return Surname.CompareTo(other.Surname);
        }

        public bool Equals(string other)
        {
            if (other is null) return false;

            return Surname == other || Name == other || Patronymic == other;
        }

        public bool Equals(Employee other)
        {
            if (other is null) return false;

            return Surname == other.Surname && Name == other.Name && Patronymic == other.Patronymic;
        }

        public override string ToString() => $"{Id} {Surname} \t{Name}\t{Patronymic}\t{Salary}\t{IdDepartment}";

    }
}
