using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TeamHost.Application.Contracts.Games.GetAllGames;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Game.GetAllGames;

/// <summary>
/// Обработчик для <see cref="GetAllGamesQuery"/>
/// </summary>
public class GetAllGamesQueryHandler
    : IRequestHandler<GetAllGamesQuery, GetAllGamesResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="distributedCache">Кеш</param>
    public GetAllGamesQueryHandler(IDbContext dbContext, IDistributedCache distributedCache)
    {
        _dbContext = dbContext;
        _distributedCache = distributedCache;
    }

    /// <inheritdoc />
    public async Task<GetAllGamesResponse> Handle(
        GetAllGamesQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var allGames = _dbContext.Games.AsNoTracking();

        var totalCount = await allGames.CountAsync(cancellationToken);
        var result = await allGames
            .Select(x => new GetAllGamesResponseItem
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                ImageUrl = x.MediaFiles
                    .Select(y => y.Path)
                    .ToList(),
                Rating = x.Rating,
                MainImage = x.MainImage!.Path,
                LastImages = x.MediaFiles
                    .Select(y => y.Path)
                    .ToList(),
                Price = x.Price,
                Category = x.Categories
                    .Select(y => y.Name)
                    .ToList(),
                Platforms = x.Platforms
                    .Select(y => y.MediaFile!.Name)
                    .ToList(),
            })
            .Where(x => string.IsNullOrEmpty(request.SearchCategory) || x.Category!.Any(y => y.ToLower() == request.SearchCategory.ToLower()))
            .ToListAsync(cancellationToken);
        
        return new GetAllGamesResponse(entities: result, totalCount: totalCount);
    }
}