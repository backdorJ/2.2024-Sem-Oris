using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Home.Controllers;

[Area("Home")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index([FromQuery] string? culture)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
        }
        
        return View();
    }
}