using Domain.Entities;
using Domain.SharedKernel;

namespace Domain.Events;

public class RequestCreatedEvent : BaseEvent
{
    public RequestCreatedEvent(Request request)
    {
        Request = request;
    }
    
    public Request Request { get; }
}