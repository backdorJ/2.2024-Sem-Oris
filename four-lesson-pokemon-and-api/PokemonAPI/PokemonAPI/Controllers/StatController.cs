using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;
using PokemonAPI.Core.Requests.Stat;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatController : ControllerBase
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="mapper">Маппер</param>
    public StatController(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить всю статистику
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpGet]
    public async Task<List<StatDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allStatistics = await _dbContext.Stats
            .ToListAsync(cancellationToken);
        
        return _mapper.Map<List<StatDto>>(allStatistics);
    }

    /// <summary>
    /// Получить статистику по покемону
    /// </summary>
    /// <param name="pokemonId">ИД покемона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статистика</returns>
    [HttpGet("{pokemonId}")]
    public async Task<List<StatDto>> GetAsync(
        [FromRoute] Guid pokemonId,
        CancellationToken cancellationToken)
    {
        var pokemon = await _dbContext.Pokemons
            .Include(x => x.Statistic)
            .FirstOrDefaultAsync(x => x.Id == pokemonId, cancellationToken)
            ?? throw new ApplicationException("Не найдена статистика по такому ИД");

        return pokemon.Statistic
            .Select(x => new StatDto
            {
                Name = x.Name,
                Value = x.Value
            })
            .ToList();
    }

    /// <summary>
    /// Изменить статистику
    /// </summary>
    /// <param name="statId">ИД статистики</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("{statId}")]
    public async Task PutAsync(
        [FromRoute] Guid statId,
        [FromBody] StatRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Value <= 0)
            throw new ApplicationException("Не может быть такое");
        
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        
        var stat = await _dbContext.Stats
            .FirstOrDefaultAsync(x => x.Id == statId, cancellationToken)
            ?? throw new ArgumentException("Не найдена статистика");

        stat.Name = request.Name ?? stat.Name;
        stat.Value = request.Value;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Создать статистику для покемона
    /// </summary>
    /// <param name="pokeId">ИД покемона</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("CreateStat/{pokeId}")]
    public async Task PostAsync(
        [FromRoute] Guid pokeId,
        [FromBody] StatRequest request,
        CancellationToken cancellationToken)
    {
        var poke = await _dbContext.Pokemons
            .Include(x => x.Statistic)
            .FirstOrDefaultAsync(x => x.Id == pokeId, cancellationToken)
            ?? throw new ApplicationException("Не удалось найти покемона");

        await _dbContext.Stats.AddAsync(new Stat
        {
            Name = request.Name ?? "unnamed",
            Value = request.Value,
            PokemonId = poke.Id,
            Poke = poke,
        }, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Удалить статистику по ИД
    /// </summary>
    /// <param name="statId">ИД статистики</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("{statId}")]
    public async Task DeleteAsync([FromRoute] Guid statId, CancellationToken cancellationToken)
    {
        var statForDelete = await _dbContext.Stats
            .FirstOrDefaultAsync(x => x.Id == statId, cancellationToken)
            ?? throw new ApplicationException("Не удалось найти статистику по ИД");

        _dbContext.Stats.Remove(statForDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}