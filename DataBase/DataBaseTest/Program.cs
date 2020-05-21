using DataBaseTest.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using DataBaseTest.Data.Entities;


namespace DataBaseTest
{

    class Program
    {

        private static string FileDep = "..\\..\\Data\\Department.txt";
        private static string FileEmp = "..\\..\\Data\\Employee.txt";

        static void Main(string[] args)
        {
            DBCheckEmployee();

            //List<string> AllDepList = DepListCreate(FileDep);
            //List<Employee> AllEmpList = CreateOrg(FileEmp, AllDepList);

            //ImportEmp(AllEmpList, AllDepList);

            EmployeeFromDepartment();

            List<Department> AllDep = AllOrgDep();
            List<Employee> AllEmp = AllOrgEmp();

            Console.ReadLine();
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



        private static void EmployeeFromDepartment()
        {
            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var Dep = db.Employees
                   .Include(employee => employee.Department)
                   .Where(employee => employee.Department.Id == 130).ToArray();

                Console.WriteLine(Dep[1].Department.NameDep);

            }
        }

        private static void DepChoice()
        {
            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var Dep_1 = db.Employees
                   .Include(employee => employee.Department)
                   .Where(employee => employee.Department.Id == 130).ToArray();

                Console.ReadLine();

                Console.WriteLine(Dep_1[0].Department.NameDep);

            }
        }

        public static void DBCheckEmployee()
        {
            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_count = db.Employees.Count();

                Console.WriteLine("Emploees in DB: {0}", students_count);
            }
        }


        public static List<string> DepListCreate(string FileName)
        {
            List<string> list = new List<string>();

            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    list.Add(line);
                }
            }
            return list;
        }

        private static void ImportEmp(List<Employee> list, List<string> dep)
        {
            int n = 0;
            if (list.Count == 0 || dep.Count == 0)
                return;
            using (var db = new OrgDB())
            {
                if (!db.Departments.Any())

                    for (int i = 0; i < dep.Count; i++)
                    {

                        var department = new Department();
                        {
                            department.NameDep = dep[i];
                        };

                        for (int j = 0; j < 4; j++)
                        {
                            var employee = new Employee();
                            {
                                employee.Surname = list[n].Surname;
                                employee.Name = list[n].Name;
                                employee.Patronymic = list[n].Patronymic;
                                employee.Salary = list[n].Salary;
                            };
                            department.Employees.Add(employee);
                            n++;
                        }
                        db.Departments.Add(department);
                    }
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);
                db.SaveChanges();
            }

        }

        private static List<Employee> CreateOrg(string FileName1, List<string> list)
        {
            List<Employee> employees = new List<Employee>();

            if (list.Count == 0) return employees;

            var rnd = new Random();
            int n = 1;

            using (var file1 = File.OpenText(FileName1))
            {
                while (!file1.EndOfStream)
                {
                    var line = file1.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');
                    if (components.Length != 3) continue;

                    var employee = new Employee();
                    employee.Id = n++;
                    employee.Surname = components[0];
                    employee.Name = components[1];
                    employee.Patronymic = components[2];
                    employee.Salary = rnd.Next(20, 300) * 1000;
                    int v = rnd.Next(1, list.Count + 1) - 1;
                    employee.Department = new Department();
                    employee.Department.Id = v;
                    employee.Department.NameDep = list[v];
                    employees.Add(employee);
                }
            }
            return employees;
        }



    }
}
