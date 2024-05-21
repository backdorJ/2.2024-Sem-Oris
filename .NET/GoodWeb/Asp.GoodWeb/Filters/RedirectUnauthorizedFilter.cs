using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.GoodWeb.Filters;

public class RedirectUnauthorizedFilter : IAsyncAuthorizationFilter
{
    /// <inheritdoc />
    public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Auth", new { returnUrl = context.HttpContext.Request.Path });
        }
        
        return Task.CompletedTask;
    }
}