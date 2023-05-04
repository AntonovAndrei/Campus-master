using Application.Common;
using MediatR;

namespace Application.Rooms.Commands.Delete;

public class DeleteRoomCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}