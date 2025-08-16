using Application.Employees.Common;
using MediatR;

namespace Application.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand(Guid Id, string Name, string Position, decimal Salary) : IRequest<EmployeeDto>;
