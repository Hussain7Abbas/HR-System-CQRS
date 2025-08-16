using Application.Employees.Common;
using Domain.Employees;
using MediatR;

namespace Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
  private readonly IEmployeeRepository _repo;
  public UpdateEmployeeCommandHandler(IEmployeeRepository repo) => _repo = repo;

  public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken ct)
  {
    var emp = await _repo.GetByIdAsync(request.Id) ?? throw new Exception("Employee not found");
    emp.UpdateSalary(request.Salary);
    emp.UpdatePosition(request.Position);
    emp.UpdateName(request.Name);
    await _repo.UpdateAsync(emp);
    return new EmployeeDto(emp.Id, emp.Name, emp.Position, emp.Salary);
  }
}
