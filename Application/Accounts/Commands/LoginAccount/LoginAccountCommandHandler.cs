using Domain.Accounts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Accounts.Commands.LoginAccount;

public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, string>
{
  private readonly IAccountRepository _accountRepository;
  private readonly IPasswordHasher<Account> _passwordHasher;
  private readonly Jwt.IJwtTokenGenerator _jwtTokenGenerator;

  public LoginAccountCommandHandler(IAccountRepository accountRepository,
      IPasswordHasher<Account> passwordHasher,
      Jwt.IJwtTokenGenerator jwtTokenGenerator)
  {
    _accountRepository = accountRepository;
    _passwordHasher = passwordHasher;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<string> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
  {
    var account = await _accountRepository.GetByEmailAsync(request.Email);

    if (account == null)
      throw new Exception("Invalid credentials");

    var verifyResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, request.Password);

    if (verifyResult == PasswordVerificationResult.Failed)
      throw new Exception("Invalid credentials");

    return _jwtTokenGenerator.GenerateToken(account);
  }
}
