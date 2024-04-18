using MediatR;
using TeamHost.Application.Contracts.Profile.EditProfile;

namespace TeamHost.Application.Features.Queries.Profile.EditProfile;

public class PutEditProfileCommand : EditProfileRequest, IRequest<bool>
{
    public PutEditProfileCommand(EditProfileRequest request)
        : base(request)
    {
    }
}