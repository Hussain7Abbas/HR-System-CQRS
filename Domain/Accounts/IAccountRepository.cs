using Domain.Common;

namespace Domain.Accounts;

public interface IAccountRepository : IRepository<Account>
{
  Task<Account?> GetByEmailAsync(string email);
}
