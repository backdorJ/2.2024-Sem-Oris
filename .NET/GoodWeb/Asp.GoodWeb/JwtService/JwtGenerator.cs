using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.GoodWeb.Entities;
using Asp.GoodWeb.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Asp.GoodWeb.JwtService;

public class JwtGenerator : IJwtGenerator
{
    private readonly IOptions<JWTOptions> _options;

    public JwtGenerator(IOptions<JWTOptions> options)
    {
        _options = options;
    }

    /// <inheritdoc />
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        };

        var signingKey = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key)),
            SecurityAlgorithms.HmacSha256);

        var jwtHandler = new JwtSecurityToken(
            issuer: _options.Value.Issuer,
            audience: "",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_options.Value.Expire),
            signingCredentials: signingKey);

        return new JwtSecurityTokenHandler().WriteToken(jwtHandler);
    }
}