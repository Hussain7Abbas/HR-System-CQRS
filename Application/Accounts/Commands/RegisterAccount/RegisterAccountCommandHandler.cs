using MediatR;

namespace Application.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Guid>
{
  public async Task<Guid> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
  {
    // TODO: Add validation, hashing, persistence later
    Guid newAccountId = Guid.NewGuid();

    // Simulate async work
    await Task.CompletedTask;

    return newAccountId;
  }
}
