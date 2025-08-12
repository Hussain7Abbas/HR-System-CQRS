namespace Domain.Users;

public class UserProfile
{
  public Guid Id { get; private set; }
  public Guid AccountId { get; private set; }
  public string FullName { get; private set; } = string.Empty;
  public string Bio { get; private set; } = string.Empty;

  private UserProfile() { }

  public UserProfile(Guid accountId, string fullName, string bio)
  {
    Id = Guid.NewGuid();
    AccountId = accountId;
    FullName = fullName;
    Bio = bio;
  }

  public void UpdateProfile(string fullName, string bio)
  {
    FullName = fullName;
    Bio = bio;
  }
}
