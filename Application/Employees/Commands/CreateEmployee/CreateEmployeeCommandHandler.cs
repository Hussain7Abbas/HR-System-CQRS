using Application.Employees.Common;
using Domain.Employees;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
  private readonly IEmployeeRepository _repo;
  public CreateEmployeeCommandHandler(IEmployeeRepository repo) => _repo = repo;

  public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken ct)
  {
    var emp = new Employee(request.Name, request.Position, request.Salary);
    await _repo.AddAsync(emp);
    return new EmployeeDto(emp.Id, emp.Name, emp.Position, emp.Salary);
  }
}
