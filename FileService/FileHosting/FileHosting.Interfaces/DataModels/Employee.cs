using System.Runtime.Serialization;

namespace FileHosting.Interfaces.DataModels
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
