using MediatR;
using TeamHost.Application.Contracts.Profile.PostRegister;

namespace TeamHost.Application.Features.Queries.Profile.PostRegister;

public class PostRegisterCommand : PostRegisterRequest, IRequest<PostRegisterResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostRegisterCommand(PostRegisterRequest request)
        : base(request)
    {
    }
}