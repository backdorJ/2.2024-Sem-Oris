using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Contracts.Chats.SendMessage;
using TeamHost.Application.Features.Queries.Chats.GetChats;
using TeamHost.Application.Features.Queries.Chats.GetMessagesChats;
using TeamHost.Application.Features.Queries.Chats.SendMessage;
using TeamHost.Application.Features.Queries.Profile.GetProfileImage;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class ChatController : Controller
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор</param>
    public ChatController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var imageUrl = await _mediator.Send(new GetProfileImageQuery());
        return View(imageUrl);
    }

    [HttpGet]
    public async Task<IActionResult> ChatsAsync()
    {
        var result = await _mediator.Send(new GetChatsQuery());
        return PartialView("_ChatsPartial", result);
    }

    [HttpGet("GetMessageInChat/{id}")]
    public async Task<IActionResult> GetChatDetailAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetMessagesChatsQuery(id));
        return PartialView("_ChatMessageBoxPartial", result);
    }

    [HttpPost("SendMessage/{chatId}")]
    public async Task<IActionResult> SendMessageAsync(
        [FromRoute] Guid chatId,
        [FromBody] SendMessageRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new SendMessageCommand(chatId, request), cancellationToken);
        return Ok();
    }
}