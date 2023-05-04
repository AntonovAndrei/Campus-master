using Application.Common;
using MediatR;

namespace Application.Rooms.Commands.Create;

public class CreateRoomCommand : IRequest<Result<Guid>>
{
    public RoomDto RoomDto { get; set; }
}