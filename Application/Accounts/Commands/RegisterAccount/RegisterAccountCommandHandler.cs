using MediatR;
using Domain.Accounts;
using Microsoft.AspNetCore.Identity;

namespace Application.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Guid>
{
  private readonly IAccountRepository _accountRepository;
  private readonly IPasswordHasher<Account> _passwordHasher;

  public RegisterAccountCommandHandler(IAccountRepository accountRepository,
                                       IPasswordHasher<Account> passwordHasher)
  {
    _accountRepository = accountRepository;
    _passwordHasher = passwordHasher;
  }

  public async Task<Guid> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
  {
    // 1. Check if email already exists
    var existing = await _accountRepository.GetByEmailAsync(request.Email);
    if (existing != null)
      throw new Exception("Email is already registered");

    // 2. Create new Account entity with hashed password
    var account = new Account(request.Email, "");
    account.UpdatePassword(_passwordHasher.HashPassword(account, request.Password));

    // 3. Persist
    await _accountRepository.AddAsync(account);

    return account.Id;
  }
}
