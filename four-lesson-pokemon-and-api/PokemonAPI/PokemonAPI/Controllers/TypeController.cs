using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeController : ControllerBase
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mapper">Маппер</param>
    /// <param name="dbContext">Контекст БД</param>
    public TypeController(IMapper mapper, IDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Получить все типы
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Все типы</returns>
    [HttpGet]
    public async Task<List<TypeDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allTypes = await _dbContext.Types.ToListAsync(cancellationToken);
        return _mapper.Map<List<TypeDto>>(allTypes);
    }

    /// <summary>
    /// Получить тип по названию
    /// </summary>
    /// <param name="typeName">Название типа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Тип</returns>
    [HttpGet("Type/{typeName}")]
    public async Task<TypeDto> GetAsync(
        [FromRoute] string typeName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(typeName))
            throw new ArgumentException("Тип не может быть пустой");
        
        var type = await _dbContext.Types
            .FirstOrDefaultAsync(x => x.Name == typeName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(typeName));

        return _mapper.Map<TypeDto>(type);
    }

    /// <summary>
    /// Добавить новый тип
    /// </summary>
    /// <param name="typeName">Название типа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("CreateType")]
    public async Task PostAsync(
        [FromBody] string typeName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(typeName))
            throw new ApplicationException("Название типа не может быть пустым");

        await _dbContext.Types.AddAsync(new Core.Entities.Type
        {
            Name = typeName,
            Pokemons = new List<Pokemon>(),
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Изменить тип
    /// </summary>
    /// <param name="typeName">Название типа</param>
    /// <param name="newTypeName">Новое название типа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("PutType/{typeName}")]
    public async Task PutAsync(
        [FromRoute] string typeName,
        [FromBody] string newTypeName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(typeName) || string.IsNullOrWhiteSpace(newTypeName))
            throw new ArgumentException("Название типа не может быть пустой");
        
        var oldType = await _dbContext.Types
            .FirstOrDefaultAsync(x => x.Name == typeName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(typeName));

        oldType.Name = newTypeName;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Удалить тип по названию
    /// </summary>
    /// <param name="typeName">Название типа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("DeleteType/{typeName}")]
    public async Task DeleteAsync([FromRoute] string typeName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(typeName))
            throw new ArgumentException("Название типа не может быть пустым");
        
        var typeForDelete = await _dbContext.Types
            .FirstOrDefaultAsync(x => x.Name == typeName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(typeName));

        _dbContext.Types.Remove(typeForDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}