using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Contracts.Profile.EditProfile;
using TeamHost.Application.Contracts.Profile.PostLogin;
using TeamHost.Application.Contracts.Profile.PostRegister;
using TeamHost.Application.Features.Queries.Profile.EditProfile;
using TeamHost.Application.Features.Queries.Profile.GetUserById;
using TeamHost.Application.Features.Queries.Profile.PostLogin;
using TeamHost.Application.Features.Queries.Profile.PostRegister;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController : Controller
{
    private readonly IMediator _mediator;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserContext _userContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="signInManager">Для входа</param>
    /// <param name="userContext">Контекст пользователя</param>
    public ProfileController(
        IMediator mediator,
        SignInManager<User> signInManager,
        IUserContext userContext)
    {
        _mediator = mediator;
        _signInManager = signInManager;
        _userContext = userContext;
    }

    // GET
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _mediator.Send(new GetUserByIdQuery(_userContext.CurrentUserId!.Value));
        
        return View(result);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditProfile([FromForm] EditProfileRequest request)
    {
        var result = await _mediator.Send(new PutEditProfileCommand(request));

        if (!result)
            return BadRequest();
        
        return View(request);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] PostLoginRequest request, string? returnUrl = null)
    {
        var result = await _mediator.Send(new PostLoginCommand(request));

        if (returnUrl != null && result)
            LocalRedirect(returnUrl);
        
        return result
            ? RedirectToAction("Index", "Home", new { area = "Home" })
            : BadRequest();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] PostRegisterRequest request)
    {
        var result = await _mediator.Send(new PostRegisterCommand(request));
        
        if (!result.IsSucceed)
            result.Errors?.ForEach(error => ModelState.AddModelError(string.Empty, error));

        return RedirectToAction("Index", "Home", new { area = "Home" });
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}