using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Application.Contracts.Profile.PostRegister;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Queries.Profile.PostRegister;

/// <summary>
/// Обработчик для <see cref="PostRegisterCommand"/>
/// </summary>
public class PostRegisterCommandHandler : IRequestHandler<PostRegisterCommand, PostRegisterResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userManager">Для пользователя</param>
    /// <param name="signInManager">Для входа</param>
    public PostRegisterCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    /// <inheritdoc />
    public async Task<PostRegisterResponse> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrEmpty(request.Email))
            throw new ApplicationException("Email обязателен");

        if (string.IsNullOrEmpty(request.Password))
            throw new ApplicationException("Password обязателен");

        if (string.IsNullOrWhiteSpace(request.Username))
            throw new ApplicationException("Username обязателен");

        var user = new User
        {
            UserName = request.Username,
            Email = request.Email,
            UserInfo = new UserInfo
            {
                FirstName = "Тимерхан",
                LastName = "Мухутдинов",
                Patronimic = "Аглямович",
                Country = new Country
                {
                    Name = "Неизвестно"
                },
            }
        };
        
        var result = await _userManager
            .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new PostRegisterResponse
            {
                IsSucceed = false,
                Errors = result.Errors
                    .Select(x => x.Description)
                    .ToList(),
            };

        await _signInManager.SignInAsync(user, false);
        
        return new PostRegisterResponse
        {
            IsSucceed = true,
            Errors = null,
        };
    }
}