using MediatR;

namespace Application.Users.Commands.UpsertMyProfile;

public record UpsertMyProfileCommand(Guid AccountId, string FullName, string Bio) : IRequest<Guid>;
