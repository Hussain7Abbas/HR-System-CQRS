using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
  private readonly AppDbContext _db;
  public EmployeeRepository(AppDbContext db) => _db = db;

  public async Task AddAsync(Employee entity)
  {
    await _db.Employees.AddAsync(entity);
    await _db.SaveChangesAsync();
  }

  public async Task DeleteAsync(Employee entity)
  {
    _db.Employees.Remove(entity);
    await _db.SaveChangesAsync();
  }

  public async Task<IEnumerable<Employee>> GetAllAsync()
  {
    return await _db.Employees.AsNoTracking().ToListAsync();
  }

  public async Task<Employee?> GetByIdAsync(Guid id)
  {
    return await _db.Employees.FindAsync(id);
  }
}
