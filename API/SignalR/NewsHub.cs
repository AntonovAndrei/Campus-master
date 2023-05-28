using Application.NewsFolder;
using Application.NewsFolder.Commands.Create;
using Application.NewsFolder.Queries.List;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR;

public class NewsHub : Hub
{
    private readonly IMediator _mediator;

    public NewsHub(IMediator mediator) 
        => _mediator = mediator;

    public async Task PublishNews(NewsDto newsDto)
    {
        var createdNewsId = await _mediator.Send(new CreateNewsCommand {NewsDto = newsDto});

        newsDto.Id = createdNewsId.Value;
        await Clients.Group("newsViewer")
            .SendAsync("ReceiveNews", newsDto);
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        await Groups.AddToGroupAsync(Context.ConnectionId, "newsViewer");
        var result = await _mediator.Send(new NewsListQuery());
        await Clients.Caller.SendAsync("LoadNews", result.Value);
    }
}