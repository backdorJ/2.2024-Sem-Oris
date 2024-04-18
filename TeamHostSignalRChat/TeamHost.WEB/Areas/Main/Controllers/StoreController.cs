using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Queries.Game.GetAllGames;
using TeamHost.Application.Features.Queries.Game.GetByIdGame;

namespace TeamHost.Areas.Main.Controllers;

[Area("Main")]
public class StoreController : Controller
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    public StoreController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Получить страницу со всеми играми
    /// </summary>
    /// <returns>Страница с играми</returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _mediator.Send(new GetAllGamesQuery()); 
        
        return View(result);
    }

    /// <summary>
    /// Получить подробную информациб об игре по ИД
    /// </summary>
    /// <param name="id">ИД игры</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Страница с подробной информацией об игре</returns>
    [HttpGet("card-store/{id}")]
    public async Task<IActionResult> Details(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetByIdGameQuery(id), cancellationToken);

        return View(result);
    }
}