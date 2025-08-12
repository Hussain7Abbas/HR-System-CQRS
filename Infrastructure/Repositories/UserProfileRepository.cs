using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
  private readonly AppDbContext _db;
  public UserProfileRepository(AppDbContext db) => _db = db;

  public async Task AddAsync(UserProfile entity)
  {
    await _db.UserProfiles.AddAsync(entity);
    await _db.SaveChangesAsync();
  }

  public async Task DeleteAsync(UserProfile entity)
  {
    _db.UserProfiles.Remove(entity);
    await _db.SaveChangesAsync();
  }

  public async Task<UserProfile?> GetByAccountIdAsync(Guid accountId)
  {
    return await _db.UserProfiles.FirstOrDefaultAsync(u => u.AccountId == accountId);
  }

  public async Task<UserProfile?> GetByIdAsync(Guid id)
  {
    return await _db.UserProfiles.FindAsync(id);
  }
}
