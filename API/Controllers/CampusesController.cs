using Application.Campuses;
using Application.Campuses.Commands.Create;
using Application.Campuses.Commands.Delete;
using Application.Campuses.Commands.Update;
using Application.Campuses.Queries.Detail;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CampusesController : BaseApiController
{
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCampus([FromQuery] Guid campusId)
    {
        return HandleResult(await Mediator.Send(new DetailCampusQuery() {CampusId = campusId}));
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