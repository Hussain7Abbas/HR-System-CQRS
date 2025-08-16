using Application.Employees.Common;
using Domain.Employees;
using MediatR;

namespace Application.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
  private readonly IEmployeeRepository _repo;
  public GetEmployeeByIdQueryHandler(IEmployeeRepository repo) => _repo = repo;

  public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken ct)
  {
    var emp = await _repo.GetByIdAsync(request.Id) ?? throw new Exception("Employee not found");
    return new EmployeeDto(emp.Id, emp.Name, emp.Position, emp.Salary);
  }
}
