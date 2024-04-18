using MediatR;
using TeamHost.Application.Contracts.Games.GetAllGames;

namespace TeamHost.Application.Features.Queries.Game.GetAllGames;

/// <summary>
/// Запрос на получения всех игр
/// </summary>
public class GetAllGamesQuery : IRequest<GetAllGamesResponse>
{
}