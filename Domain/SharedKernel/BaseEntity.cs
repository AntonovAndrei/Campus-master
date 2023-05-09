namespace Domain.SharedKernel;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    private readonly List<BaseEvent> _domainEvents = new List<BaseEvent>();
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(BaseEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}