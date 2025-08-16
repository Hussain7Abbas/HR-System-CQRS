using Application.Employees.Common;
using MediatR;

namespace Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(string Name, string Position, decimal Salary) : IRequest<EmployeeDto>;
