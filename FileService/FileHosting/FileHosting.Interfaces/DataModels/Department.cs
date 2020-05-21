using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FileHosting.Interfaces.DataModels
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string NameDep { get; set; }

        [DataMember]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [DataContractFormat]
        public static Department[] GetDepartments()
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

    }

}
