using MediatR;
using Microsoft.EntityFrameworkCore;
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

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetAllGamesQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

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
            .ToListAsync(cancellationToken);
        
        return new GetAllGamesResponse(entities: result, totalCount: totalCount);
    }
}