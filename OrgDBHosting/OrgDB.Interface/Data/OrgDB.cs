using OrgDBHosting.Interface.Data;
using System.Data.Entity;
using System.Runtime.Serialization;

using System.ServiceModel;

namespace OrgDBHosting.Interface.Data
{
    [DataContract]
    public class OrgDB : DbContext
    {
        [DataMember]
        public DbSet<Employee> Employees { get; set; }

        [DataMember]
        public DbSet<Department> Departments { get; set; }

        public OrgDB() : this("name=OrgDB") { }

        public OrgDB(string ConnectionString) : base(ConnectionString) { }

    }

}
