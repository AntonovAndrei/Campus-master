using Domain.Entities;
using Domain.SharedKernel;

namespace Domain.Events;

public class RequestStatusChangedEvent : BaseEvent
{
    public RequestStatusChangedEvent(Request request)
    {
        Request = request;
    }
    
    public Request Request { get; }
}