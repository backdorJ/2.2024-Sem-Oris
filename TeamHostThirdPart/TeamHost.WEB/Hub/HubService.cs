using Microsoft.AspNetCore.SignalR;
using TeamHost.Application.Interfaces;
using TeamHost.Application.Models;

namespace TeamHost.Hub;

public class HubService : IHubService
{
    private readonly IHubContext<ChatHub> _hubContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="hubContext">Контекст хаба</param>
    public HubService(IHubContext<ChatHub> hubContext)
        => _hubContext = hubContext;

    /// <inheritdoc />
    public async Task SendNewMessageAsync(SendMessageModel model)
    {
        if (model.SentTo?.Any() == false)
            return;

        await _hubContext.Clients
            .Users(model.SentTo!
                .Select(x => x.ToString())
                .ToList()!)
            .SendAsync("ReceiveMessage", new
            {
                model.Text,
                model.WhoSentId,
                Images = model.Images
                .Select(y => new
                {
                    UserId = y.Key,
                    Image = y.Value
                })
                .ToList(),
                model.SenderName,
            });
    }
}