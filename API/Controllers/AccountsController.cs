using Application.Accounts.Commands.RegisterAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
  private readonly IMediator _mediator;

  public AccountsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterAccountCommand command)
  {
    var accountId = await _mediator.Send(command);
    return Ok(new { accountId });
  }
}