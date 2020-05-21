using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Xml.Serialization;
using OrgDBHosting.Interface;
using OrgDBHosting.Interface.Data;

namespace OrgDBHosting.Services
{
    [ServiceBehavior(
    //InstanceContextMode = InstanceContextMode.PerCall,
    //ConcurrencyMode = ConcurrencyMode.Multiple,
    //AutomaticSessionShutdown = true,
    MaxItemsInObjectGraph = 10000,
    IncludeExceptionDetailInFaults = true
    )]
    public class OrgDBHost : IOrgDB
    {
        public Department[] GetDepartments()
        {
            List<Department> deplist = new List<Department>();
            using (var db = new OrgDB())
            {
                var alldep = db.Departments;
                foreach (var department in alldep)
                    deplist.Add(department);
            }

            return deplist.ToArray();
        }

        //public Employee[] GetEmployee()
        //{
        //    List<Employee> emplist = new List<Employee>();
        //    using (var db = new OrgDB())
        //    {
        //        var allemp = db.Employees;
        //        foreach (var employee in allemp)
        //            emplist.Add(employee);
        //    }

        //    return emplist.ToArray();
        //}
    }
}
