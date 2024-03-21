using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.JsonDtos;
using PokemonAPI.Core.Urls;
using Ability = PokemonAPI.Core.Entities.Ability;
using Pokemon = PokemonAPI.Core.Entities.Pokemon;
using Type = PokemonAPI.Core.Entities.Type;

namespace PokemonAPI.Core.Services;

public class DbSeeder : IDbSeeder
{
    private readonly HttpClient _httpClient;

    private readonly ILogger<DbSeeder> _logger;
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="httpClient">Клиент http</param>
    /// <param name="logger">Логгер</param>
    /// <param name="dbContext">Контекст БД</param>
    public DbSeeder(
        HttpClient httpClient,
        ILogger<DbSeeder> logger,
        IDbContext dbContext)
    {
        _httpClient = httpClient;
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await SeedTypesAsync(cancellationToken);
        await SeedAbilitiesAsync(cancellationToken);
        await SeedMovesAsync(cancellationToken);
        
        using var response = await _httpClient
        .GetAsync($"{BaseUrls.UrlPokemon}?limit=1302", cancellationToken: cancellationToken)
        ?? throw new ArgumentNullException(nameof(BaseUrls.UrlPokemon));
        
        if (!response.IsSuccessStatusCode)
            _logger.LogCritical($"Seed was failed. {response.StatusCode}");

        var basePokesByJson = await response.Content.ReadAsStringAsync(cancellationToken);
        
        if (string.IsNullOrWhiteSpace(basePokesByJson))
            _logger.LogCritical($"JSON was bad!");

        var basePokes = JsonConvert.DeserializeObject<Poke>(basePokesByJson)
            ?? throw new ArgumentException("Результат десериализации вернул null");

        var allPokes = await _dbContext.Pokemons
            .ToListAsync(cancellationToken);

        var order = 1;
        foreach (var poke in basePokes.Pokes)
        {
            if (allPokes.Any(x => x.Name.Equals(poke.PokeName, StringComparison.OrdinalIgnoreCase)))
                continue;
            
            using var pokeInfo = await _httpClient
                .GetAsync($"{BaseUrls.UrlPokemon}/{poke.PokeName.ToLower()}", cancellationToken)
                ?? throw new ArgumentException($"Мы не смогли получить ответ из запроса");
            
            if (!pokeInfo.IsSuccessStatusCode)
                _logger.LogCritical($"Что то пошло не так при отправке запроса на подробную информация для покемона");

            var pokeInfoJson = await pokeInfo.Content.ReadAsStringAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(pokeInfoJson))
                continue;

            var pokeInfoFromJson = JsonConvert.DeserializeObject<PokeInfo>(pokeInfoJson);
            var newPoke = await AddNewPokeAsync(pokeInfoFromJson, order, poke, cancellationToken);
            
            await _dbContext.Pokemons.AddAsync(newPoke, cancellationToken);
            order++;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedTypesAsync(CancellationToken cancellationToken)
    {
        using var response = await _httpClient.GetAsync(BaseUrls.UrlTypes, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            _logger.LogCritical($"Не получилось получить типы для покемонов");

        var typesJson = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(typesJson))
            return;

        var typesFromJson = JsonConvert.DeserializeObject<JsonType>(typesJson)
            ?? throw new ApplicationException("Не получилось десериализовать типы");

        var typesFromDb = await _dbContext.Types.ToListAsync(cancellationToken);

        var types = typesFromJson.Types
            .Where(type => !typesFromDb.Any(x => x.Name.Equals(type.Name, StringComparison.OrdinalIgnoreCase)))
            .Select(type => new Type
            {
                Name = type.Name ?? "unnamed",
                Pokemons = new List<Pokemon>(),
            })
            .ToList();
        
        await _dbContext.Types.AddRangeAsync(types, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedAbilitiesAsync(CancellationToken cancellationToken)
    {
        var abilitiesFromDb = await _dbContext.Abilities
            .ToListAsync(cancellationToken);
        
        var response = await _httpClient.GetAsync(BaseUrls.UrlAbilities, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            _logger.LogCritical($"Не получилось получить способности для покемонов");

        var abilitiesJson = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(abilitiesJson))
            return;
        
        var abilitiesFromJson = JsonConvert.DeserializeObject<JsonAbility>(abilitiesJson)
            ?? throw new ApplicationException("Не получилось десериализовать способности покемонов");

        var abilities = abilitiesFromJson.Abilities
            .Where(x => !abilitiesFromDb.Any(y => y.Name.Equals(x.Name, StringComparison.OrdinalIgnoreCase)))
            .Select(x => new Ability
            {
                Name = x.Name,
                Pokemons = new List<Pokemon>(),
            })
            .ToList();

        await _dbContext.Abilities.AddRangeAsync(abilities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedMovesAsync(CancellationToken cancellationToken)
    {
        var movesFromDb = await _dbContext.Moves
            .ToListAsync(cancellationToken);

        var response = await _httpClient.GetAsync(BaseUrls.UrlMoves, cancellationToken);
        
        if (!response.IsSuccessStatusCode)
            _logger.LogCritical("Не получилось получить движений для покемонов");

        var movesJson = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(movesJson))
            return;

        var movesFromJson = JsonConvert.DeserializeObject<JsonMove>(movesJson)
            ?? throw new ApplicationException("Не получилось десериализировать движения для покемонов");

        var moves = (movesFromJson.Moves ?? new())
            .Where(x => !movesFromDb.Any(y => y.Name.Equals(x.Name, StringComparison.OrdinalIgnoreCase)))
            .Select(x => new Move
            {
                Name = x.Name ?? "unnamed",
            })
            .ToList();

        await _dbContext.Moves.AddRangeAsync(moves, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Pokemon> AddNewPokeAsync(
        PokeInfo? pokeInfoFromJson,
        int order,
        BasePoke poke,
        CancellationToken cancellationToken)
    {
        var newPoke = new Pokemon
            {
                Order = pokeInfoFromJson?.Id ?? 0,
                Name = poke.PokeName,
                ImageUrl = pokeInfoFromJson?.Sprites?.Other?.Home?.FrontShiny ?? "unnamed",
            };
            
        newPoke.Statistic = (pokeInfoFromJson?.Stats ?? new())
            .Select(x => new Stat
            {
                Id = Guid.NewGuid(),
                Name = x.Stat?.Name ?? "unnamed",
                Value = x.BaseStat,
                PokemonId = newPoke.Id,
                Poke = newPoke
            })
            .ToList();

        var abilitiesNames = (pokeInfoFromJson?.Abilities ?? new())
            .Select(x => x.Ability?.Name ?? string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .ToList();
        
        var abilities = await _dbContext.Abilities
            .Where(x => abilitiesNames
                .Contains(x.Name.ToLower()))
            .ToListAsync(cancellationToken);
        
        abilities.ForEach(x =>
        {
            x.Pokemons.Add(newPoke);
        });

        newPoke.Abilities.AddRange(abilities);
        newPoke.Breeding = new Breeding
        {
            Id = Guid.NewGuid(),
            Weight = pokeInfoFromJson?.Weight ?? 0.0,
            Height = pokeInfoFromJson?.Height ?? 0.0,
            Pokemon = newPoke,
            PokemonId = newPoke.Id
        };

        var moveNames = (pokeInfoFromJson?.Moves ?? new())
            .Select(x => x.MoveItem.Name ?? string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .ToList();
        
        var moves = await _dbContext.Moves
            .Where(x => moveNames
                .Contains(x.Name.ToLower()))
            .ToListAsync(cancellationToken);
        
        moves.ForEach(x =>
        {
            x.Pokemons.Add(newPoke);
        });
        newPoke.Moves.AddRange(moves);

        var typeNames = (pokeInfoFromJson!.Types ?? new())
            .Select(y => y.Type?.Name ?? string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .ToList();

        var types = await _dbContext.Types
            .Where(x => typeNames.Contains(x.Name.ToLower()))
            .ToListAsync(cancellationToken);

        types.ForEach(x =>
        {
            x.Pokemons.Add(newPoke);
        });

        newPoke.Types.AddRange(types);

        return newPoke;
    }
}