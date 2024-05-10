using TeamHost.Application.Models;

namespace TeamHost.Application.Interfaces;

public interface IHubService
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <param name="model">Модель письма</param>
    public Task SendNewMessageAsync(SendMessageModel model);
}