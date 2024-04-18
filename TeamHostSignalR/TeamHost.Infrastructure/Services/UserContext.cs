using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TeamHost.Application.Interfaces;

namespace TeamHost.Infrastructure.Services;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="httpContextAccessor">Http акссесор</param>
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public Guid? CurrentUserId =>
        Guid.TryParse(User?.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value, out var userId)
            ? userId
            : null;

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
}