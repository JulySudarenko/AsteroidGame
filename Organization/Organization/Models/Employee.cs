using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;


//July Sudarenko

namespace Organization.Models
{
    public class Employee : INotifyPropertyChanged //IComparable<Employee>, IEquatable<string>, IEquatable<Employee>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        private string _Surname;
        private string _Name;
        private string _Patronymic;
        private double _Salary;
        public Department Department { get; set; }

        public string Surname
        {
            get => _Surname;
            set
            {
                if (_Surname == value) return;
                _Surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name == value) return;
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Patronymic
        {
            get => _Patronymic;
            set
            {
                if (_Patronymic == value) return;
                _Patronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Patronymic)));
            }
        }

        public double Salary
        {
            get => _Salary;
            set
            {
                if (_Salary == value) return;
                _Salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }

        public override string ToString() => $"[{Id}] {Surname} \t{Name}\t{Patronymic}\t{Salary}\t{Department}";

        public Employee(string Surname, string Name, string Patronymic)
        {
            Random rnd = new Random();

            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            Salary = rnd.Next(20, 300) * 1000;
        }

        public Employee()
        {
        }

        //public static string NameDepForEmployee(Employee employee, Department department)
        //{
        //    if (employee.IdDepartment == department.Id)
        //        return $"{department.NameDep}";
        //    return null;
        //}

        //public int CompareTo(Employee other)
        //{
        //    if (other is null) return 1;
        //    return Surname.CompareTo(other.Surname);
        //}

        //public bool Equals(string other)
        //{
        //    if (other is null) return false;

        //    return Surname == other || Name == other || Patronymic == other;
        //}

        //public bool Equals(Employee other)
        //{
        //    if (other is null) return false;

        //    return Surname == other.Surname && Name == other.Name && Patronymic == other.Patronymic;
        //}




        //internal class Student : INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    public int Id { get; set; }


        //    private string _Name;

        //    public string Name
        //    {
        //        get => _Name;
        //        set
        //        {
        //            if (_Name == value) return;
        //            _Name = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        //        }
        //    }

        //    public string Surname { get; set; }

        //    public string Patronymic { get; set; }

        //    public StudentsGroup Group { get; set; }
        
    }
}
