using Domain.Events;
using MediatR;

namespace Application.Requests.EventHandlers;

public class RequestCreatedEventHandler : INotificationHandler<RequestCreatedEvent>
{
    public Task Handle(RequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}