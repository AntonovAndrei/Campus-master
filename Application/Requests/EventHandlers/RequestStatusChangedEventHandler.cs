using Domain.Enums;
using Domain.Events;
using MediatR;

namespace Application.Requests.EventHandlers;

public class RequestStatusChangedEventHandler : INotificationHandler<RequestStatusChangedEvent>
{
    public Task Handle(RequestStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        Console.Beep(5000, 1000);
        Console.WriteLine("Srabotalo srabotalo");
        
        return Task.CompletedTask;
    }
}