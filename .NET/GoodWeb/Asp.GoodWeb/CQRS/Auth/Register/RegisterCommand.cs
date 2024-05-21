using Asp.GoodWeb.Contracts.Contracts.Auth.Register;
using MediatR;

namespace Asp.GoodWeb.CQRS.Auth.Register;

public class RegisterCommand : RegisterRequest, IRequest<string>
{
    public RegisterCommand(RegisterRequest request)
        : base(request)
    {
    }
}