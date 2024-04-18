using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

[Area("Main")]
public class StreamController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}