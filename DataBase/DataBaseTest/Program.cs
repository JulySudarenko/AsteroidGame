using DataBaseTest.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace DataBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OrgDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_count = db.Employees.Count();

                Console.WriteLine("Emploees in DB: {0}", students_count);

            }




            Console.ReadLine();
        }

        //private static void Import(string FileName)
        //{
        //    using (var db = new OrgDB())
        //        if (!db.Employees.Any())
        //        {
        //        }

        //}
        //private static List<Employee> CreateOrg(string FileName1, List<string> list)
        //{
        //    List<Employee> employees = new List<Employee>();

        //    if (list.Count == 0) return employees;

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
        //        var student_n = 1;
        //        for (var group_n = 1; group_n <= 10; group_n++)
        //        {
        //            var group = new StudentsGroup
        //            {
        //                Name = $"Group {group_n}"
        //            };

        //            for (var i = 0; i < 10; i++)
        //            {
        //                var student = new Student
        //                {
        //                    Name = $"Student {student_n}",
        //                    Surname = $"Surname {student_n}",
        //                    Patronymic = $"Patronymic {student_n}",
        //                };
        //                group.Students.Add(student);
        //                student_n++;

        //                //db.Students.Add(student); // в этом нет необходимости!
        //            }

        //            db.Groups.Add(group);
        //        }

        //        db.Database.Log = str => Console.WriteLine("EF>> {0}", str);
        //        db.SaveChanges();
        //    }


        //using (var db = new StudentsDB())
        //{
        //    db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

        //    var students_group_id_7 = db.Students
        //       //.Include(student => student.Group)
        //       .Where(student => student.Group.Id == 7).ToArray();

        //    Console.ReadLine();

        //    Console.WriteLine(students_group_id_7[0].Group.Name);
        //}




        private static List<string> DepListCreate(string FileName)
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
    }
}
