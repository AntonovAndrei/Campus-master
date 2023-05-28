using Application.Common.Pagination;
using Application.Requests;
using Application.Requests.Commands.ChangeStatus;
using Application.Requests.Commands.Create;
using Application.Requests.Commands.Delete;
using Application.Requests.Commands.Update;
using Application.Requests.Queries.List;
using Application.Requests.Queries.ListById;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RequestsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new RequestListQuery {Params = param}));
    }
    
    [HttpGet("by-curent-resident")]
    public async Task<IActionResult> GetCurrentResidentList([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new RequestCurrentResidentListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRequests(CreateRequestDto requesttDto)
    {
        return HandleResult(await Mediator.Send(new CreateRequestCommand {CreateRequestDto = requesttDto}));
    }
    
    [Authorize(Policy = "MustBeRequestCreator")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRequests(Guid id, CreateRequestDto requesttDto)
    {
        requesttDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateRequestCommand {CreateRequestDto = requesttDto}));
    }
    
    [Authorize(Policy = "MustBeRequestCreator")]
    [HttpPut("{id}/status/{status}")]
    public async Task<IActionResult> ChangeStatus(Guid id, RequestStatus status)
    {
        return HandleResult(await Mediator.Send(new ChangeStatusCommand {RequestId = id, RequestStatus = status}));
    }
    
    [Authorize(Policy = "MustBeRequestCreator")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequests(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteRequestCommand {Id = id}));
    }
}