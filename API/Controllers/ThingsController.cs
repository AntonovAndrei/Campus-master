﻿using Application.Common.Pagination;
using Application.Things;
using Application.Things.Commands.Create;
using Application.Things.Commands.Delete;
using Application.Things.Commands.Update;
using Application.Things.Queries.List;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = Roles.SupplyManager)]
public class ThingsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetThings([FromQuery] PagingParams param)
    {
        return HandleResult(await Mediator.Send(new ListThingQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateThing(ThingDto thingDto)
    {
        return HandleResult(await Mediator.Send(new CreateThingCommand {ThingDto = thingDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateThing(Guid id, ThingDto thingDto)
    {
        thingDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateThingCommand {ThingDto = thingDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThing(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteThingCommand {Id = id}));
    }
}