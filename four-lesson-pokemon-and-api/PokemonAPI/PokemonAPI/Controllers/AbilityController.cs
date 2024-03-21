using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbilityController : ControllerBase
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="mapper">Маппер</param>
    public AbilityController(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить все способности
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список способностей</returns>
    [HttpGet]
    public async Task<List<AbilityDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allAbilities = await _dbContext.Abilities.ToListAsync(cancellationToken);
        return _mapper.Map<List<AbilityDto>>(allAbilities);
    }
    
    /// <summary>
    /// Поличь способность по названию
    /// </summary>
    /// <param name="abilityName">Название способности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Способность</returns>
    [HttpGet("Ability/{abilityName}")]
    public async Task<AbilityDto> GetAsync(
        [FromRoute] string abilityName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(abilityName))
            throw new ArgumentException("Название способности не может быть пустой");
        
        var ability = await _dbContext.Abilities
            .FirstOrDefaultAsync(x => x.Name == abilityName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(abilityName));
        
        return _mapper.Map<AbilityDto>(ability);
    }
    
    /// <summary>
    /// Создать способность
    /// </summary>
    /// <param name="abilityName">Название способности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("CreateAbility")]
    public async Task PostAsync(
        [FromBody] string abilityName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(abilityName))
            throw new ArgumentException("Название способности не может быть пустым");
        
        await _dbContext.Abilities.AddAsync(new Ability
        {
            Name = abilityName,
            Pokemons = new List<Pokemon>(),
        },
        cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Изменить способность
    /// </summary>
    /// <param name="abilityName">Название старой способности</param>
    /// <param name="newAbilityName">Название новой способности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("PutAbility/{abilityName}")]
    public async Task PutAsync(
        [FromRoute] string abilityName,
        [FromBody] string newAbilityName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(abilityName) || string.IsNullOrWhiteSpace(newAbilityName))
            throw new ArgumentException("Название способности не может быть пустой");

        var oldAbility = await _dbContext.Abilities
            .FirstOrDefaultAsync(x => x.Name == abilityName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(abilityName));

        oldAbility.Name = newAbilityName;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Удалить способность
    /// </summary>
    /// <param name="abilityName">Название </param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("DeleteAbility/{abilityName}")]
    public async Task DeleteAsync(
        [FromRoute] string abilityName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(abilityName))
            throw new ArgumentException("Название способности не может быть пустой");
        
        var abilityForDelete = await _dbContext.Abilities
            .FirstOrDefaultAsync(x => x.Name == abilityName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(abilityName));

        _dbContext.Abilities.Remove(abilityForDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}