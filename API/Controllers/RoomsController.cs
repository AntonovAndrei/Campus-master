using System.Security.Claims;
using Application.Common.Pagination;
using Application.Rooms;
using Application.Rooms.Commands.Create;
using Application.Rooms.Commands.Delete;
using Application.Rooms.Commands.Update;
using Application.Rooms.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoomsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetRooms([FromQuery] PagingParams param)
    {
        var identity = (ClaimsIdentity)User.Identity;
        var roles = ((ClaimsIdentity)User.Identity).Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value);
        Console.WriteLine(roles);
        return HandleResult(await Mediator.Send(new RoomListQuery {Params = param}));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRoom(RoomDto roomDto)
    {
        return HandleResult(await Mediator.Send(new CreateRoomCommand {RoomDto = roomDto}));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(Guid id, RoomDto roomDto)
    {
        roomDto.Id = id;
        return HandleResult(await Mediator.Send(new UpdateRoomCommand {RoomDto = roomDto}));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteRoomCommand {Id = id}));
    }
}