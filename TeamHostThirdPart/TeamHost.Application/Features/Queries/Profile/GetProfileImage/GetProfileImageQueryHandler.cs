using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Profile.GetProfileImage;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Profile.GetProfileImage;

/// <summary>
/// Обработчик для <see cref="GetProfileImageQuery"/>
/// </summary>
public class GetProfileImageQueryHandler : IRequestHandler<GetProfileImageQuery, GetProfileImageResponse?>
{
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;

    public GetProfileImageQueryHandler(IDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    /// <inheritdoc />
    public async Task<GetProfileImageResponse?> Handle(GetProfileImageQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return await _dbContext.UserInfos
            .Where(x => x.UserId == _userContext.CurrentUserId)
            .Select(x => new GetProfileImageResponse
            {
                ImageUrl = x.Image!.Path,
                CurrentUserId = _userContext.CurrentUserId,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}