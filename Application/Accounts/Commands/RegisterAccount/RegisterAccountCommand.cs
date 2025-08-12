using MediatR;

namespace Application.Accounts.Commands.RegisterAccount;

public record RegisterAccountCommand(string Email, string Password) : IRequest<Guid>;
