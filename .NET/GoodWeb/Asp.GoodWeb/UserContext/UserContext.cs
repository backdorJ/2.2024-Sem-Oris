using System.Security.Claims;

namespace Good.API.Services.UserContext;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public Guid? CurrentUserId => Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id)
        ? id
        : null;

    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
}