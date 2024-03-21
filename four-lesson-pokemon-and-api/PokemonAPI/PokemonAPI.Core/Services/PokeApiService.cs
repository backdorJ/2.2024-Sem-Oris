using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;
using PokemonAPI.Core.Requests.GetPokeByFilter;
using PokemonAPI.Core.Requests.GetPokeByName;

namespace PokemonAPI.Core.Services;

/// <summary>
/// Сервис для работы с покемонами
/// </summary>
public class PokeApiService : IPokeService
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="mapper">Маппер</param>
    public PokeApiService(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<GetPokeByFilterResponse> GetPokeByFilterAsync(
        GetPokeByFilterRequest request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var query = _dbContext.Pokemons
            .OrderBy(x => x.Order)
            .AsQueryable();

        query = query
            .Where(x => string.IsNullOrEmpty(request.Search)
                        || x.Name.ToLower().Contains(request.Search.ToLower()))
            .OrderBy(x => x.Order);

        var totalCount = await query.CountAsync(cancellationToken);
        
        var pokes = await query
            .SkipTake(request)
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var results = _mapper.Map<List<PokemonDto>>(pokes);

        return new GetPokeByFilterResponse(results, totalCount);
    }

    /// <inheritdoc />
    public async Task<GetPokeByNameResponse> GetPokeByNameAsync(string pokeName, CancellationToken cancellationToken)
        => await _dbContext.Pokemons
            .AsNoTracking()
            .Include(x => x.Abilities)
            .Include(x => x.Statistic)
            .Include(x => x.Moves)
            .Include(x => x.Types)
            .Include(x => x.Breeding)
            .Select(x => new GetPokeByNameResponse
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Order = x.Order,
                Breeding = new GetPokeBreedingResponse
                {
                    Weight = x.Breeding!.Weight,
                    Height = x.Breeding.Height,
                },
                Abilities = x.Abilities
                    .Select(y => new GetPokeAbilityResponseItem
                    {
                        Name = y.Name
                    })
                    .ToList(),
                Moves = x.Moves
                    .Select(y => new GetPokeMoveResponseItem
                    {
                        Name = y.Name,
                    })
                    .ToList(),
                Types = x.Types
                    .Select(y => new GetPokeTypeResponseItem
                    {
                        Name = y.Name
                    })
                    .ToList(),
                Statistic = x.Statistic
                    .Select(y => new GetPokeStatResponseItem
                    {
                        Name = y.Name,
                        Value = y.Value,
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(x => x.Name.ToLower() == pokeName.ToLower(), cancellationToken)
            ?? throw new ApplicationException($"Не удалось найти покемона по имени '{pokeName}'");
}