using Application.Common.Pagination;
using Application.Requests.RequestTypes;
using Application.Requests.RequestTypes.Commands.Create;
using Application.Requests.RequestTypes.Commands.Delete;
using Application.Requests.RequestTypes.Commands.Update;
using Application.Requests.RequestTypes.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("request-types")]
public class RequestTypesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new RequestTypeListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRequestTypes(RequestTypeDto requestTypetDto)
    {
        return HandleResult(await Mediator.Send(new CreateRequestTypeCommand {RequestTypeDto = requestTypetDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRequestTypes(Guid id, RequestTypeDto requestTypetDto)
    {
        requestTypetDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateRequestTypeCommand {RequestTypeDto = requestTypetDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequestTypes(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteRequestTypeCommand {Id = id}));
    }
}