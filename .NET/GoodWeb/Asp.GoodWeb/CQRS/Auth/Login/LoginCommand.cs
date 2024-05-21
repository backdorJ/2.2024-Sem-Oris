using Asp.GoodWeb.Contracts.Contracts.Auth.Login;
using MediatR;

namespace Asp.GoodWeb.CQRS.Auth.Login;

public class LoginCommand : LoginRequest, IRequest<string>
{
    public LoginCommand(LoginRequest request)
        : base(request)
    {
    }
}