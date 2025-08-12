using MediatR;

namespace Application.Accounts.Commands.LoginAccount;

public record LoginAccountCommand(string Email, string Password) : IRequest<string>;
