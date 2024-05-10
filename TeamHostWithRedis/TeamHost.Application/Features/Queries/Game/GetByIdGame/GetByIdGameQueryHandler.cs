using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using TeamHost.Application.Contracts.Games.GetByIdGame;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Game.GetByIdGame;

/// <summary>
/// Обработчик для <see cref="GetByIdGameQuery"/>
/// </summary>
public class GetByIdGameQueryHandler : IRequestHandler<GetByIdGameQuery, GetByIdGameResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IDistributedCache _distributedCache;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="distributedCache">Сервис для работы с Redis</param>
    public GetByIdGameQueryHandler(IDbContext dbContext, IDistributedCache distributedCache)
    {
        _dbContext = dbContext;
        _distributedCache = distributedCache;
    }

    /// <inheritdoc />
    public async Task<GetByIdGameResponse> Handle(
        GetByIdGameQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var gameFromCache = await _distributedCache.GetStringAsync(request.Id.ToString(), cancellationToken);

        if (gameFromCache != null)
            return JsonConvert.DeserializeObject<GetByIdGameResponse>(gameFromCache)
            ?? throw new ArgumentException("Что то пошло не так при десерилизации объекта");

        var gameFromDb = await _dbContext.Games
            .Where(x => x.Id == request.Id)
            .Select(x => new GetByIdGameResponse
            {
                Id = x.Id,
                Name = x.Name,
                MainImage = x.MainImage!.Path,
                MediaFiles = x.MediaFiles
                    .Where(z => z.Id != x.MainImageId)
                    .Select(y => y.Path)
                    .ToList(),
                Description = x.Description,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                Platforms = x.Platforms
                    .Select(y => y.MediaFile!.Name)
                    .ToList(),
                Company = x.Developer!.Name,
                Price = x.Price,
                Categories = x.Categories
                    .Select(y => y.Name)
                    .ToList(),
            })
            .FirstAsync(cancellationToken)
            ?? throw new ApplicationException($"Игра с ИД {request.Id} не найдена");

        await _distributedCache
            .SetAsync(
                gameFromDb.Id.ToString(),
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(gameFromDb)),
                cancellationToken);

        return gameFromDb;
    }
}