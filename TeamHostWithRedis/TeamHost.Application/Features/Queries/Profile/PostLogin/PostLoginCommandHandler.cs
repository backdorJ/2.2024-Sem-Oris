using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Queries.Profile.PostLogin;

public class PostLoginCommandHandler : IRequestHandler<PostLoginCommand, bool>
{
    private readonly SignInManager<User> _signInManager;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="signInManager">Сервис для входа</param>
    public PostLoginCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

        return result.Succeeded;
    }
}