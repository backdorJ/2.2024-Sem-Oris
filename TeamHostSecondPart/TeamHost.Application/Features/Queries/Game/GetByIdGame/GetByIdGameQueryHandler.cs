using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Games.GetByIdGame;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Game.GetByIdGame;

/// <summary>
/// Обработчик для <see cref="GetByIdGameQuery"/>
/// </summary>
public class GetByIdGameQueryHandler : IRequestHandler<GetByIdGameQuery, GetByIdGameResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetByIdGameQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetByIdGameResponse> Handle(
        GetByIdGameQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return await _dbContext.Games
            .Where(x => x.Id == request.Id)
            .Select(x => new GetByIdGameResponse
            {
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
    }
}