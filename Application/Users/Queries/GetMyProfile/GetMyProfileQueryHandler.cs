using Domain.Users;
using MediatR;

namespace Application.Users.Queries.GetMyProfile;

public class GetMyProfileQueryHandler : IRequestHandler<GetMyProfileQuery, UserProfileDto>
{
  private readonly IUserProfileRepository _repo;

  public GetMyProfileQueryHandler(IUserProfileRepository userProfileRepository) => _repo = userProfileRepository;

  public async Task<UserProfileDto> Handle(GetMyProfileQuery request, CancellationToken ct)
  {
    var profile = await _repo.GetByAccountIdAsync(request.AccountId)
                 ?? throw new Exception("Profile not found");

    return new UserProfileDto(profile.Id, profile.AccountId, profile.FullName, profile.Bio);
  }
}
