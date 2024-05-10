using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

[Area("Main")]
public class CommunityController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}