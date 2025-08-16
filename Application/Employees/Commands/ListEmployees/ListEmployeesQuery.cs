using Application.Employees.Common;
using MediatR;

namespace Application.Employees.Queries.ListEmployees;

public record ListEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;
