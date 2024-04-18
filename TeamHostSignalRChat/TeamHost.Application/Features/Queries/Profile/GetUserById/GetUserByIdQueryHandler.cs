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

        return await _dbContext.UserInfos
            .Where(x => x.UserId == request.Id)
             .Select(x => new GetUserByIdResponse
             {
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                 Patronymic = x.Patronimic,
                 Birthday = x.Birthday,
                 About = x.About,
                 Country = x.Country,
                 ProfileImageUrl = x.Image!.Path,
             })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new ApplicationException("Пользователь не найден");
    }
}