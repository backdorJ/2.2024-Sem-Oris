namespace Good.API.Services.UserContext;

public interface IUserContext
{
    Guid? CurrentUserId { get; }
}