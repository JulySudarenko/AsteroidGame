using System.Data.Entity;
using DataBaseTest.Data.Entities;

namespace DataBaseTest.Data
{
    class OrgDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public OrgDB() : this("name=OrgDB") { }

        public OrgDB(string ConnectionString) : base(ConnectionString) { }

    }
}
