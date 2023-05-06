using Application.Common.Pagination;
using Application.Users.Residents;
using Application.Users.Residents.Commands.Create;
using Application.Users.Residents.Commands.Delete;
using Application.Users.Residents.Commands.Update;
using Application.Users.Residents.Queries.Detail;
using Application.Users.Residents.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ResidentsController : BaseApiController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        return HandleResult(await Mediator.Send(new DetailResidentQuery(){ResidentId = id}));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PagingParams param)
    {
        return HandleResult(await Mediator.Send(new ResidentListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateResidents(CreateResidentDto residentDto)
    {
        return HandleResult(await Mediator.Send(new CreateResidentCommand {ResidentDto = residentDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResidents(Guid id, CreateResidentDto residentDto)
    {
        residentDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateResidentCommand {ResidentDto = residentDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResidents(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteResidentCommand {ResidentId = id}));
    }
}