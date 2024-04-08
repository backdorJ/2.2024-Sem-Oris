using System.ComponentModel.DataAnnotations.Schema;
using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Common;

public class BaseEntity : IEntity
{
    /// <inheritdoc />
    public Guid Id { get; set; }
    
    private readonly List<BaseEvent> _domainEvents = new();
 
    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
 
    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}