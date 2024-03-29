using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
public class FavouriteController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}