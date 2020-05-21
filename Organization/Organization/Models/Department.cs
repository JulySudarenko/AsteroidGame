using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

//July Sudarenko
namespace Organization.Models

{
    public class Department// : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string NameDep { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        //public event PropertyChangedEventHandler PropertyChanged;

        //public int Id { get; set;}
        //public string _NameDep;
        //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();


        public override string ToString() => NameDep;// $"[{Id}] {NameDep}";

        //public string NameDep
        //{
        //    get => _NameDep;
        //    set
        //    {
        //        if (_NameDep == value) return;
        //        _NameDep = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NameDep)));
        //    }
        //}

        //public Department(int Id, string NameDep, ICollection<Employee> Employees)
        //{
        //    this.Id = Id;
        //    this.NameDep = NameDep;
        //    this.Employees = Employees;
        //}

        //public Department()
        //{
        //}
    }
}
