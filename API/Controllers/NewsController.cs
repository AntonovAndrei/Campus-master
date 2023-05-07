using Application.Common.Pagination;
using Application.NewsFolder;
using Application.NewsFolder.Commands.Create;
using Application.NewsFolder.Commands.Delete;
using Application.NewsFolder.Commands.Update;
using Application.NewsFolder.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class NewsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetNews([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new GetNewsListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNews(NewsDto newsDto)
    {
        return HandleResult(await Mediator.Send(new CreateNewsCommand {NewsDto = newsDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNews(Guid id, NewsDto newsDto)
    {
        newsDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateNewsCommand {NewsDto = newsDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNews(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteNewsCommand {Id = id}));
    }
}