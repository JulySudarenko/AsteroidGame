using Organization.ViewModels.Base;
using Organization.Models;
using Organization.Services;
using DataBaseTest.Data;
using System.Windows;

namespace Organization.ViewModels
{
    internal class DepartmentViewModel : ViewModel
    {

        //public Department NewDepartment { get; } = new Department();

        //public DepartmentViewModel()
        //{
        //    NewDepAdd(TextDep);
        //}
        private static void NewDepAdd(string text)
        {
            using (var db = new OrgDB())
            {
                Department Department = new Department();

                Department.NameDep = text;
                db.Departments.Add(Department);
                db.SaveChanges();
            }
        }
    }
}
