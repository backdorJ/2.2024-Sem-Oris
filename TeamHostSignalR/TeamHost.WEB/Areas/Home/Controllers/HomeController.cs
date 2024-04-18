using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Home.Controllers;

[Area("Home")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}