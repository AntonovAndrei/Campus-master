using Application.Common;
using MediatR;
using Persistence;

namespace Application.Rooms.Commands.Delete;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Result<Unit>>
{
    private readonly CampusContext _context;

    public DeleteRoomCommandHandler(CampusContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.FindAsync(request.Id);

        if (room == null) return null;

        _context.Remove(room);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the room");

        return Result<Unit>.Success(Unit.Value);
    }
}