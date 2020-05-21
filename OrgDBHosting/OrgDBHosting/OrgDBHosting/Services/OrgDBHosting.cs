using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Xml.Serialization;
using OrgDBHosting.Interface;
using OrgDBHosting.Data.Entity;
using OrgDBHosting.Data;

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
        //Student s1, s2;
        //using (var bin_file = File.Open("student.bin", FileMode.Open))
        //using (var xml_file = File.Open("student.xml", FileMode.Open))
        //{
        //    s1 = (Student) binary_formatter.Deserialize(bin_file);
        //    s2 = (Student) xml_serializer.Deserialize(xml_file);
        //}
        public void GetDepartments()
        {
            var xml_serializer = new XmlSerializer(typeof(Department));
            //List<Department> deplist = new List<Department>();
            using (var db = new OrgDB())
            using (var xml_file = File.Create("department.xml"))
            {
                //var dep = db.Departments;
                foreach (var d in db.Departments)
                    xml_serializer.Serialize(xml_file, d);
                //deplist.Add(d);
            }

        }

        public void GetEmployees()
        {
            var xml_serializer = new XmlSerializer(typeof(Employee));
            using (var db = new OrgDB())
            using (var xml_file = File.Create("employee.xml"))
            {
                foreach (var e in db.Employees)
                    xml_serializer.Serialize(xml_file, e);
            }
        }
    }
}
