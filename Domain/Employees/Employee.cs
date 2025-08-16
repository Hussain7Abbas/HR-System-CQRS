namespace Domain.Employees;

public class Employee
{
  public Guid Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string Position { get; private set; } = string.Empty;
  public decimal Salary { get; private set; }

  private Employee() { }

  public Employee(string name, string position, decimal salary)
  {
    Id = Guid.NewGuid();
    Name = name;
    Position = position;
    Salary = salary;
  }

  public void UpdatePosition(string position) => Position = position;
  public void UpdateSalary(decimal salary) => Salary = salary;

  public void UpdateName(string name) => Name = name;
}
