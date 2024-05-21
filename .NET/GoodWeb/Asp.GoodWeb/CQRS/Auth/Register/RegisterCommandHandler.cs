using Asp.GoodWeb.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Asp.GoodWeb.CQRS.Auth.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly IDbContext _dbContext;

    public RegisterCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;
    
    /// <inheritdoc />
    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrEmpty(request.Email))
            throw new ApplicationException("Почта обязательна");
        
        if (!request.Password.Equals(request.ConfirmPassword))
            throw new ApplicationException("Пароли не совпадают");

        var isExistInDb = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (isExistInDb != null)
            throw new ApplicationException("Пользователь с такой почтой зарегестрирован");
        
        var user = Entities.User.CreateUser(request.Username, request.Email, request.Password);

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return "yes";
    }
}