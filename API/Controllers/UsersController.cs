using System.Security.Claims;
using Application.Users.Commands.UpsertMyProfile;
using Application.Users.Queries.GetMyProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
  private readonly IMediator _mediator;
  public UsersController(IMediator mediator) => _mediator = mediator;

  private Guid GetAccountId() =>
      Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                 User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                 User.FindFirstValue(ClaimTypes.Name) ??  // fallback
                 throw new Exception("Account id claim missing"));

  [HttpGet("me")]
  public async Task<IActionResult> Me()
  {
    var accountId = GetAccountId();
    var dto = await _mediator.Send(new GetMyProfileQuery(accountId));
    return Ok(dto);
  }

  [HttpPut("me")]
  public async Task<IActionResult> Upsert([FromBody] UpsertMyProfileCommand body)
  {
    var accountId = GetAccountId();
    var id = await _mediator.Send(body with { AccountId = accountId });
    return Ok(new { id });
  }
}
