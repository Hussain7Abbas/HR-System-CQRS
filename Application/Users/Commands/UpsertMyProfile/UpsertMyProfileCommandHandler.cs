using Domain.Users;
using MediatR;

namespace Application.Users.Commands.UpsertMyProfile;

public class UpsertMyProfileCommandHandler : IRequestHandler<UpsertMyProfileCommand, Guid>
{
  private readonly IUserProfileRepository _repo;

  public UpsertMyProfileCommandHandler(IUserProfileRepository repo) => _repo = repo;

  public async Task<Guid> Handle(UpsertMyProfileCommand request, CancellationToken ct)
  {
    var existing = await _repo.GetByAccountIdAsync(request.AccountId);
    if (existing is null)
    {
      var created = new UserProfile(request.AccountId, request.FullName, request.Bio);
      await _repo.AddAsync(created);
      return created.Id;
    }

    existing.UpdateProfile(request.FullName, request.Bio);
    await _repo.UpdateAsync(existing);
    return existing.Id;
  }
}
