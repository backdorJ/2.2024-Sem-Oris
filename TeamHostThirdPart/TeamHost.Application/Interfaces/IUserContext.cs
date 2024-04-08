namespace TeamHost.Application.Interfaces;

public interface IUserContext
{
    Guid? CurrentUserId { get; }
}