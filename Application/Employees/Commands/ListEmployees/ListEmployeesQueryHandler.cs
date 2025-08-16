using Application.Employees.Common;
using Domain.Employees;
using MediatR;

namespace Application.Employees.Queries.ListEmployees;

public class ListEmployeesQueryHandler : IRequestHandler<ListEmployeesQuery, IEnumerable<EmployeeDto>>
{
  private readonly IEmployeeRepository _repo;
  public ListEmployeesQueryHandler(IEmployeeRepository repo) => _repo = repo;

  public async Task<IEnumerable<EmployeeDto>> Handle(ListEmployeesQuery request, CancellationToken ct)
  {
    var all = await _repo.GetAllAsync();
    return all.Select(e => new EmployeeDto(e.Id, e.Name, e.Position, e.Salary));
  }
}
