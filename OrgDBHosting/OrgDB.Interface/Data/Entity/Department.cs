using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace OrgDBHosting.Interface.Data.Entity
{
    [DataContract]
    [Serializable]
    public class Department : ISerializable
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string NameDep { get; set; }

        [DataMember]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        Department()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var xml_serializer = new XmlSerializer(typeof(Department));
            List<Department> deplist = new List<Department>();
            using (var db = new OrgDB())
            {
                var alldep = db.Departments;
                foreach (var department in alldep)
                    deplist.Add(department);
            }
            using (var xml_file = File.Create("department.xml"))
            {
                foreach (var d in deplist)
                    xml_serializer.Serialize(xml_file, d);
            }
        }
    }
}
