using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OrgDBHosting.Interface.Data
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

        public override string ToString() => $"[{Id}] {NameDep}";


    }
}
