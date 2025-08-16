using Domain.Common;

namespace Domain.Employees;

public interface IEmployeeRepository : IRepository<Employee>
{
  Task<IEnumerable<Employee>> GetAllAsync();
  Task UpdateAsync(Employee entity);
}
