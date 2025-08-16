using Application.Employees.Common;
using Domain.Employees;
using MediatR;

namespace Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, EmployeeDto>
{
  private readonly IEmployeeRepository _repo;
  public DeleteEmployeeCommandHandler(IEmployeeRepository repo) => _repo = repo;

  public async Task<EmployeeDto> Handle(DeleteEmployeeCommand request, CancellationToken ct)
  {
    var emp = await _repo.GetByIdAsync(request.Id) ?? throw new Exception("Employee not found");
    await _repo.DeleteAsync(emp);
    return new EmployeeDto(emp.Id, emp.Name, emp.Position, emp.Salary);
  }
}
