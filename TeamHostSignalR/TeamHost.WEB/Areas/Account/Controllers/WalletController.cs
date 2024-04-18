using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class WalletController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}