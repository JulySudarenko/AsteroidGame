using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//July Sudarenko
namespace Organization.Models

{
    public class Department
    {
        public int Id { get; set; }
        public string NameDep { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public override string ToString() => $"[{Id}] {NameDep}";

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
