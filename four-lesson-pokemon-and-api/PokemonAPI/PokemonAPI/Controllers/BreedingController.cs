using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;
using PokemonAPI.Core.Requests.Breeding;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BreedingController : ControllerBase
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mapper">Маппер</param>
    /// <param name="dbContext">Контекст БД</param>
    public BreedingController(IMapper mapper, IDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Получить все характеристики
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Все характеристики</returns>
    [HttpGet]
    public async Task<List<BreedingDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allBreedings = await _dbContext.Breeding.ToListAsync(cancellationToken);
        return _mapper.Map<List<BreedingDto>>(allBreedings);
    }

    /// <summary>
    /// Получить характеристику
    /// </summary>
    /// <param name="breedingId">ИД характеристики</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Характеристика</returns>
    [HttpGet("{breedingId}")]
    public async Task<BreedingDto> GetAsync(
        [FromRoute] Guid breedingId,
        CancellationToken cancellationToken)
    {
        var breeding = await _dbContext.Breeding
            .FirstOrDefaultAsync(x => x.Id == breedingId, cancellationToken)
            ?? throw new ArgumentException("Не найден 'Breeding' с таким ИД");

        return _mapper.Map<BreedingDto>(breeding);
    }

    /// <summary>
    /// Создать характеристику
    /// </summary>
    /// <param name="pokeId">Ид покемона</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("createBreeding/{pokeId}")]
    public async Task PostAsync(
        [FromRoute] Guid pokeId,
        [FromBody] BreedingRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Height <= 0 || request.Weight <= 0)
            throw new ArgumentException("Вес или рост не может быть меньше 0");
        
        var poke = await _dbContext.Pokemons
            .FirstOrDefaultAsync(x => x.Id == pokeId, cancellationToken)
            ?? throw new ArgumentException("Не найден покемон с таким ИД");

        if (poke.Breeding != null)
            throw new ApplicationException("У данного покемона уже заданы характеристики");

        await _dbContext.Breeding.AddAsync(new Breeding
        {
            Weight = request.Weight,
            Height = request.Height,
            Pokemon = poke,
            PokemonId = poke.Id,
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Изменить характеристику
    /// </summary>
    /// <param name="breedingId">ИД характеристику</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("{breedingId}")]
    public async Task PutAsync(
        [FromRoute] Guid breedingId,
        [FromBody] BreedingRequest request,
        CancellationToken cancellationToken)
    {
        var breeding = await _dbContext.Breeding
            .FirstOrDefaultAsync(x => x.Id == breedingId, cancellationToken)
            ?? throw new ApplicationException($"Не найдена характеристика по ИД '{breedingId}'");

        breeding.Weight = request.Weight;
        breeding.Height = request.Height;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Удалить характеристику
    /// </summary>
    /// <param name="breedingId">ИД характеристики</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("{breedingId}")]
    public async Task DeleteAsync([FromRoute] Guid breedingId, CancellationToken cancellationToken)
    {
        var breedingForDelete = await _dbContext.Breeding
            .FirstOrDefaultAsync(x => x.Id == breedingId, cancellationToken)
            ?? throw new ApplicationException("Не удалось найти характеристику по ИД");

        _dbContext.Breeding.Remove(breedingForDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}