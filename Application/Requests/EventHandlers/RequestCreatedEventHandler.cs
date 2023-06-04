using Application.Common.Interfaces;
using Domain.Enums;
using Domain.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Application.Requests.EventHandlers;

public class RequestCreatedEventHandler : INotificationHandler<RequestCreatedEvent>
{
    private readonly IRequestHub _hubContext;
    public RequestCreatedEventHandler(IRequestHub hubContext)
    {
        _hubContext = hubContext;
    }
    public Task Handle(RequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        _hubContext.StatusChanged(notification.Request);
        
        return Task.CompletedTask;
    }
}