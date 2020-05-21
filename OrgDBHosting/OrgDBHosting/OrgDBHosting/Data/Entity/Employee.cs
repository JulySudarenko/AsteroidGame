using System;


namespace OrgDBHosting.Data.Entity
{

    [Serializable]
    public class Employee
    {

        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public double Salary { get; set; }

        public Department Department { get; set; }
    }
}
