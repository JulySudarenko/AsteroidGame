using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//July Sudarenko
namespace Organization
{
    public class Department
    {
        public int Id { get; set; }
        public string NameDep { get; set; }

        public Department(int Id, string NameDep)
        {
            this.Id = Id;
            this.NameDep = NameDep;
        }

        public Department()
        {
        }

        public override string ToString() => $"{Id} {NameDep}";

        //public static List<Department> CreateDepartment(string FileName)
        //{
        //    List<Department> departments = new List<Department>();

        //    int n = 1;

        //    using (var file = File.OpenText(FileName))
        //    {
        //        while (!file.EndOfStream)
        //        {
        //            var line = file.ReadLine();

        //            if (string.IsNullOrWhiteSpace(line)) continue;

        //            //var component = line;//.Split(' ');
        //            //if (components.Length != 3) continue;

        //            var department = new Department();
        //            department.Id = n++;
        //            department.NameDep = line;
        //            departments.Add(department);
        //        }
        //    }

        //    return departments;
        //}
    }
}
