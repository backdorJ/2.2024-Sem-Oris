using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Profile.GetUserById;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Queries.Profile.GetUserById;

/// <summary>
/// Обработчик для <see cref="GetUserByIdQuery"/>
/// </summary>
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    public GetUserByIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (!request.Id.HasValue)
            throw new ApplicationException("Пользователь не найден");

        var userInfoFromDb = await _dbContext.UserInfos
            .Include(x => x.User)
            .Include(x => x.Country)
            .FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken)
            ?? throw new ApplicationException("Пользователь не найден");

        return new GetUserByIdResponse
        {
            FirstName = userInfoFromDb.FirstName,
            LastName = userInfoFromDb.LastName,
            Patronymic = userInfoFromDb.Patronimic,
            Birthday = userInfoFromDb.Birthday,
            About = userInfoFromDb.About,
            Country = userInfoFromDb.Country,
        };
    }
}