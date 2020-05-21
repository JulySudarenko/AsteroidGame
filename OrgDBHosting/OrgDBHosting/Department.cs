using System;

namespace OrgDBClient.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string NameDep { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public override string ToString() => NameDep; // $"[{Id}] {NameDep}";

    }

}