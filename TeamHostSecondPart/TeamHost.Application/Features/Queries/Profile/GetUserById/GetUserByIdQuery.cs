using MediatR;
using TeamHost.Application.Contracts.Profile.GetUserById;

namespace TeamHost.Application.Features.Queries.Profile.GetUserById;

/// <summary>
/// Запрос на получения пользователя
/// </summary>
public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">ИД пользователя</param>
    public GetUserByIdQuery(Guid id)
        => Id = id;

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid? Id { get; set; }
}