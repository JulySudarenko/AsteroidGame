using OrgDBHosting.Interface.Data.Entity;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace OrgDBHosting.Data
{
    public class OrgDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public OrgDB() : this("name=OrgDB") { }

        public OrgDB(string ConnectionString) : base(ConnectionString) { }

    }

}
