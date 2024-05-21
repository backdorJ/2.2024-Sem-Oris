using Asp.GoodWeb.Entities;

namespace Asp.GoodWeb.JwtService;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}