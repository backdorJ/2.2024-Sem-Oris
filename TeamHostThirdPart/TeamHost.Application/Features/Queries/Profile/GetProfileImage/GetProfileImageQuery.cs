using MediatR;
using TeamHost.Application.Contracts.Profile.GetProfileImage;

namespace TeamHost.Application.Features.Queries.Profile.GetProfileImage;

/// <summary>
/// Запрос на получение фото пользователя
/// </summary>
public class GetProfileImageQuery : IRequest<GetProfileImageResponse?>
{
}