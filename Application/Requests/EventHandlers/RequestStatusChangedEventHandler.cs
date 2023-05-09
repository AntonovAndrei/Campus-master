using Domain.Enums;
using Domain.Events;
using MediatR;

namespace Application.Requests.EventHandlers;

public class RequestStatusChangedEventHandler : INotificationHandler<RequestStatusChangedEvent>
{
    public Task Handle(RequestStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}