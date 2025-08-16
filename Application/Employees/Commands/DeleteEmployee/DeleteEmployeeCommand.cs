using Application.Employees.Common;
using MediatR;

namespace Application.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(Guid Id) : IRequest<EmployeeDto>;
