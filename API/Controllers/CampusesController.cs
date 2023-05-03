using Application.Common.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CampusesController : BaseApiController
{
    
    [HttpGet]
    public async Task<IActionResult> GetCampuss([FromQuery] PagingParams param)
    {
        return HandleResult(await Mediator.Send(new GetCampusListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCampus(CampusDto campusDto)
    {
        return HandleResult(await Mediator.Send(new CreateCampusCommand {CampusDto = campusDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCampus(Guid id, CampusDto campusDto)
    {
        campusDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateCampusCommand {CampusDto = campusDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCampus(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteCampusCommand {Id = id}));
    }
}