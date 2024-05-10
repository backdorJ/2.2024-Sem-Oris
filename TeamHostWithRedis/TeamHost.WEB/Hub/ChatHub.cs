using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace TeamHost.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private static readonly List<string> _usersOnline = new List<string>();
    
    /// <inheritdoc />
    public override async Task OnConnectedAsync()
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        _usersOnline.Add(userId!);
        
        await Clients.All.SendAsync("OnConnection", new
        {
            _usersOnline
        });
    }

    /// <inheritdoc />
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        _usersOnline.Remove(userId!);
        await Clients.All
            .SendAsync(
                "OnDisconnected", new
                {
                    userId
                });
    }
}