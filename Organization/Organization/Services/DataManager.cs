using System;
using System.IO;
using System.Collections.Generic;
using Organization.Models;
using DataBaseTest.Data;

namespace Organization.Services
{
    public class DataManager
    {

        //public List<Employee> AllOrg { get; }
        //public List<string> AllDepartments { get; }
        public List<Department> AllDepartments { get; }
        public List<Employee> AllOrg { get; }
        public DataManager()
        {
            //AllDepartments = DepListCreate("..\\..\\Data\\Department.txt");
            //AllOrg = CreateOrg("..\\..\\Data\\Employee.txt", AllDepartments);
            AllDepartments = AllOrgDep();
            AllOrg = AllOrgEmp();

        }

        private static List<Department> AllOrgDep()
        {
            List<Department> deplist = new List<Department>();

            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var dep = db.Departments;
                foreach (var d in dep)
                    deplist.Add(d);
            }

            return deplist;
        }

        private static List<Employee> AllOrgEmp()
        {
            List<Employee> emplist = new List<Employee>();

            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var emp = db.Employees;
                foreach (var e in emp)
                    emplist.Add(e);
            }

            return emplist;
        }

        //private static List<string> DepListCreate(string FileName)
        //{
        //    List<string> list = new List<string>();

        //    using (var file = File.OpenText(FileName))
        //    {
        //        while (!file.EndOfStream)
        //        {
        //            var line = file.ReadLine();

        //            if (string.IsNullOrWhiteSpace(line)) continue;

        //            list.Add(line);
        //        }
        //    }
        //    return list;
        //}

        //private static List<Employee> CreateOrg(string FileName1, List<string> list)
        //{
        //    List<Employee> employees = new List<Employee>();

        //    if(list.Count == 0) return employees;

        //    var rnd = new Random();
        //    int n = 1;

        //    using (var file1 = File.OpenText(FileName1))
        //    {
        //        while (!file1.EndOfStream)
        //        {
        //            var line = file1.ReadLine();

        //            if (string.IsNullOrWhiteSpace(line)) continue;

        //            var components = line.Split(' ');
        //            if (components.Length != 3) continue;

        //            var employee = new Employee();
        //            employee.Id = n++;
        //            employee.Surname = components[0];
        //            employee.Name = components[1];
        //            employee.Patronymic = components[2];
        //            employee.Salary = rnd.Next(20, 300) * 1000;
        //            int v = rnd.Next(1, list.Count + 1) - 1;
        //            employee.Department = new Department();
        //            employee.Department.Id = v;
        //            employee.Department.NameDep = list[v];
        //            employees.Add(employee);
        //        }
        //    }
        //    return employees;
        //}



    }

}
