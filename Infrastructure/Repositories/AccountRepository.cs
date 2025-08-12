using Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
  private readonly AppDbContext _db;

  public AccountRepository(AppDbContext db) => _db = db;

  public async Task AddAsync(Account entity)
  {
    await _db.Accounts.AddAsync(entity);
    await _db.SaveChangesAsync();
  }

  public async Task DeleteAsync(Account entity)
  {
    _db.Accounts.Remove(entity);
    await _db.SaveChangesAsync();
  }

  public async Task<Account?> GetByIdAsync(Guid id)
  {
    return await _db.Accounts.Include(a => a.Profile).FirstOrDefaultAsync(a => a.Id == id);
  }

  public async Task<Account?> GetByEmailAsync(string email)
  {
    return await _db.Accounts.Include(a => a.Profile)
                             .FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
  }
}
