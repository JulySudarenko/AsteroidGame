using System.Collections.Generic;

namespace DataBaseTest.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string NameDep { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
