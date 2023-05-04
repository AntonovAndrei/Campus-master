using Application.Common;
using MediatR;

namespace Application.Rooms.Commands.Update;

public class UpdateRoomCommand : IRequest<Result<Unit>>
{
    public RoomDto RoomDto { get; set; }
}