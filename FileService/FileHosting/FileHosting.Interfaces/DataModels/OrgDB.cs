using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FileHosting.Interfaces.DataModels
{

    public class OrgDB : DbContext
    {

        public DbSet<Employee> Employees { get; set; }


        public DbSet<Department> Departments { get; set; }

        
        public OrgDB() : this("name=OrgDB") { }
        
        public OrgDB(string ConnectionString) : base(ConnectionString) { }

    }
}
