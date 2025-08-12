namespace Application.Accounts.Jwt;

public interface IJwtTokenGenerator
{
  string GenerateToken(Domain.Accounts.Account account);
}
