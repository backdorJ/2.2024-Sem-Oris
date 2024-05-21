using Asp.GoodWeb.Data;
using Asp.GoodWeb.JwtService;
using Good.API.Services.Hasher;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Asp.GoodWeb.CQRS.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IHasherPassword _hasherPassword;
    private readonly IDbContext _dbContext;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginCommandHandler(
        IHasherPassword hasherPassword,
        IDbContext dbContext,
        IJwtGenerator jwtGenerator, IHttpContextAccessor httpContextAccessor)
    {
        _hasherPassword = hasherPassword;
        _dbContext = dbContext;
        _jwtGenerator = jwtGenerator;
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    /// <inheritdoc />
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var userFromDb = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
            ?? throw new ArgumentNullException("Такого пользователя нет");

        var token = _jwtGenerator.GenerateToken(userFromDb);
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("some-data", token);

        return token;
    }
}