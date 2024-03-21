using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.Core.Modules.Models;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoveController : ControllerBase
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="mapper">Маппер</param>
    public MoveController(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить все движения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpGet]
    public async Task<List<MoveItem>> GetAllAsync(CancellationToken cancellationToken)
    {
        var allMovies = await _dbContext.Moves.ToListAsync(cancellationToken);
        return _mapper.Map<List<MoveItem>>(allMovies);
    }

    /// <summary>
    /// Получить движение по имени
    /// </summary>
    /// <param name="moveName">Название движения</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список движений</returns>
    [HttpGet("Move/{moveName}")]
    public async Task<MoveItem> GetAsync(
        [FromRoute] string moveName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(moveName))
            throw new ArgumentException("Название движения не может быть пустым");
        
        var move = await _dbContext.Moves
            .FirstOrDefaultAsync(x => x.Name == moveName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(moveName));

        return _mapper.Map<MoveItem>(move);
    }

    /// <summary>
    /// Создать движение
    /// </summary>
    /// <param name="moveName">Название движения</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("CreateMove")]
    public async Task PostAsync([FromBody] string moveName, CancellationToken cancellationToken)
    {
        await _dbContext.Moves.AddAsync(new Move
        {
            Name = moveName,
            Pokemons = new List<Pokemon>(),
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Изменить движение
    /// </summary>
    /// <param name="moveName">Название движения</param>
    /// <param name="newMoveName">Название старого движения</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("PutMove/{moveName}")]
    public async Task PutAsync(
        [FromRoute] string moveName,
        [FromBody] string newMoveName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(moveName) || string.IsNullOrEmpty(newMoveName))
            throw new ApplicationException("Движения не могу быть пустыми");

        var oldMove = await _dbContext.Moves
            .FirstOrDefaultAsync(x => x.Name == moveName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(moveName));

        oldMove.Name = newMoveName;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Удалить движения
    /// </summary>
    /// <param name="moveName">Название движения</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("DeleteMove/{moveName}")]
    public async Task DeleteAsync(
        [FromRoute] string moveName,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(moveName))
            throw new ApplicationException("Движения не может быть пустой");
        
        var moveForDelete = await _dbContext.Moves
            .FirstOrDefaultAsync(x => x.Name == moveName, cancellationToken)
            ?? throw new ArgumentNullException(nameof(moveName));

        _dbContext.Moves.Remove(moveForDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}