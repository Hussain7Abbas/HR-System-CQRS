using Domain.Users;
namespace Domain.Accounts;

public class Account
{
  public Guid Id { get; private set; }
  public string Email { get; private set; } = string.Empty;
  public string PasswordHash { get; private set; } = string.Empty;
  public DateTime CreatedAt { get; private set; }

  // Navigation
  public UserProfile? Profile { get; private set; }

  private Account() { } // For EF Core

  public Account(string email, string passwordHash)
  {
    Id = Guid.NewGuid();
    Email = email;
    PasswordHash = passwordHash;
    CreatedAt = DateTime.UtcNow;
  }

  public void UpdatePassword(string newHash)
  {
    PasswordHash = newHash;
  }
}
