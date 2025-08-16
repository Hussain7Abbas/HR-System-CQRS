using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Commands.DeleteEmployee;
using Application.Employees.Commands.UpdateEmployee;
using Application.Employees.Queries.GetEmployeeById;
using Application.Employees.Queries.ListEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
  private readonly IMediator _mediator;
  public EmployeesController(IMediator mediator) => _mediator = mediator;

  [HttpGet]
  public async Task<IActionResult> List() =>
      Ok(await _mediator.Send(new ListEmployeesQuery()));

  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetById(Guid id) =>
      Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand cmd) =>
      Ok(await _mediator.Send(cmd));

  [HttpPut("{id:guid}")]
  public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand cmd) =>
      Ok(await _mediator.Send(cmd with { Id = id }));

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _mediator.Send(new DeleteEmployeeCommand(id));
    return NoContent();
  }
}
