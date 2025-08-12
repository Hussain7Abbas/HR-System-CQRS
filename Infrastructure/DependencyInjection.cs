using Domain.Accounts;
using Domain.Employees;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Infrastructure.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(opts =>
        opts.UseNpgsql(configuration.GetConnectionString("Postgres")));

    // Repositories
    services.AddScoped<IAccountRepository, AccountRepository>();
    services.AddScoped<IUserProfileRepository, UserProfileRepository>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    return services;
  }
}
