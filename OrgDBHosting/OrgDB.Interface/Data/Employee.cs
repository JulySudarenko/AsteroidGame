using System;
using System.Runtime.Serialization;

namespace OrgDBHosting.Interface.Data
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Surname { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Patronymic { get; set; }

        [DataMember]
        public double Salary { get; set; }

        [DataMember]
        public Department Department { get; set; }
    }
}
