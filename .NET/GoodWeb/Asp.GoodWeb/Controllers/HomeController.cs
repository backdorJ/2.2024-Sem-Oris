using System.Diagnostics;
using Asp.GoodWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Asp.GoodWeb.Models;
using Good.API.Services.UserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Asp.GoodWeb.Controllers;


[IgnoreAntiforgeryToken]
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserContext _userContext;
    private readonly IDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, IUserContext userContext, IDbContext dbContext)
    {
        _logger = logger;
        _userContext = userContext;
        _dbContext = dbContext;
    }

    
    [IgnoreAntiforgeryToken]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("data")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> GetAccount()
    {
        var data = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == _userContext.CurrentUserId);
        
        return Ok($"Hello world, you did it ID: ({data.Id}) Email: ({data.Email})  Username: ({data.Username})");
    }
}