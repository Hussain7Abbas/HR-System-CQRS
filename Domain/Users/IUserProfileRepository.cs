using Domain.Common;

namespace Domain.Users;

public interface IUserProfileRepository : IRepository<UserProfile>
{
  Task<UserProfile?> GetByAccountIdAsync(Guid accountId);
}
