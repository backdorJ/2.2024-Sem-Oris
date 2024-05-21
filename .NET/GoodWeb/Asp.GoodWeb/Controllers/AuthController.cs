using Asp.GoodWeb.Contracts.Contracts.Auth.Login;
using Asp.GoodWeb.Contracts.Contracts.Auth.Register;
using Asp.GoodWeb.CQRS.Auth.Login;
using Asp.GoodWeb.CQRS.Auth.Register;
using Asp.GoodWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asp.GoodWeb.Controllers;

[IgnoreAntiforgeryToken]
public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [IgnoreAntiforgeryToken]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    [IgnoreAntiforgeryToken]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task Register([FromBody] RegisterRequest request)
    {
        await _mediator.Send(new RegisterCommand(request));
    }
    
    [HttpPost("login")]
    public async Task Login([FromBody] LoginRequest request)
    {
        await _mediator.Send(new LoginCommand(request));
    }
}
