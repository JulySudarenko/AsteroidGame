using System;

public class Employee
{
    public int Id { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public double _Salary { get; set; }

    public Department Department { get; set; }


}

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    //public override string ToString() => $"[{Id}]{Name}";
}
