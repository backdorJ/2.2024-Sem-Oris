using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Extensions;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Profile.EditProfile;

public class PutEditProfileCommandHandler : IRequestHandler<PutEditProfileCommand, bool>
{
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="userContext">Контекст пользователя</param>
    public PutEditProfileCommandHandler(IDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(PutEditProfileCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var userFromDb = await _dbContext.Users
            .Include(x => x.UserInfo)
                .ThenInclude(y => y.Country)
            .FirstOrDefaultAsync(x => x.Id == _userContext.CurrentUserId!.Value, cancellationToken)
            ?? throw new ApplicationException("Пользователь не найден");

        var country = await _dbContext.Countries
            .FirstOrDefaultAsync(x => x.Id == request.Country, cancellationToken)
            ?? throw new ApplicationException("Не найдена страна");
        
        if (userFromDb.UserInfo is null)
            throw new ArgumentNullException(nameof(userFromDb.UserInfo));
        
        userFromDb.UserInfo.UpdateInfo(
            firstName: request.FirstName,
            lastName: request.LastName,
            patronomic: request.Patronymic,
            about: request.About,
            birthday: request.Birthday.GetCorrectDateTime(),
            country: country);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}