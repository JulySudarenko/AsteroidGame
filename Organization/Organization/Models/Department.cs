using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

//July Sudarenko
namespace Organization.Models

{
    public class Department : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        private string _NameDep;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public override string ToString() => $"[{Id}] {_NameDep}";

        public string NameDep
        {
            get => _NameDep;
            set
            {
                if (_NameDep == value) return;
                _NameDep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NameDep)));
            }
        }

        //public Department(int Id, string NameDep)
        //{
        //    this.Id = Id;
        //    this.NameDep = NameDep;
        //}

        //public Department()
        //{
        //}
    }
}
