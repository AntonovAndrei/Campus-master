using Application.Common.Pagination;
using Application.Requests;
using Application.Requests.Commands.ChangeStatus;
using Application.Requests.Commands.Create;
using Application.Requests.Commands.Delete;
using Application.Requests.Commands.Update;
using Application.Requests.Queries.List;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RequestsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new RequestListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRequests(CreateRequestDto residentDto)
    {
        return HandleResult(await Mediator.Send(new CreateRequestCommand {CreateRequestDto = residentDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRequests(Guid id, CreateRequestDto residentDto)
    {
        residentDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateRequestCommand {CreateRequestDto = residentDto}));
    }
    
    [HttpPut("{id}/status/{status}")]
    public async Task<IActionResult> ChangeStatus(Guid id, RequestStatus status)
    {
        return HandleResult(await Mediator.Send(new ChangeStatusCommand {RequestId = id, RequestStatus = status}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequests(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteRequestCommand {Id = id}));
    }
}