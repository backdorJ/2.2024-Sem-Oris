using MediatR;
using TeamHost.Application.Contracts.Profile.PostLogin;

namespace TeamHost.Application.Features.Queries.Profile.PostLogin;

public class PostLoginCommand : PostLoginRequest, IRequest<bool>
{
    public PostLoginCommand(PostLoginRequest request)
        : base(request)
    {
    }
}