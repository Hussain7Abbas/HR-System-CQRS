using MediatR;

namespace Application.Users.Queries.GetMyProfile;

public record GetMyProfileQuery(Guid AccountId) : IRequest<UserProfileDto>;

public record UserProfileDto(Guid Id, Guid AccountId, string FullName, string Bio);
