using Application.Common.Pagination;
using Application.Professions;
using Application.Professions.Commands.Create;
using Application.Professions.Commands.Delete;
using Application.Professions.Commands.Update;
using Application.Professions.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProfessionsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetProfessions([FromQuery] PagingParams param)
    {
        return HandleResult(await Mediator.Send(new GetProfessionListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProfession(ProfessionDto professionDto)
    {
        return HandleResult(await Mediator.Send(new CreateProfessionCommand {ProfessionDto = professionDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfession(Guid id, ProfessionDto professionDto)
    {
        professionDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateProfessionCommand {ProfessionDto = professionDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfession(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteProfessionCommand {Id = id}));
    }
}