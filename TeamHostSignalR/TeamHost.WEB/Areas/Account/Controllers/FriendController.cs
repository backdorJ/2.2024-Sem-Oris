using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class FriendController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}