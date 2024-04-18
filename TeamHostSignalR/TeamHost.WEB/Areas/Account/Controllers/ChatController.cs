using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}