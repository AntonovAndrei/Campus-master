using Application.Common;
using MediatR;
using Persistence;

namespace Application.Things.Commands.Delete;

public class DeleteThingCommandHandler : IRequestHandler<DeleteThingCommand, Result<Unit>>
{
    private readonly CampusContext _context;

    public DeleteThingCommandHandler(CampusContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteThingCommand request, CancellationToken cancellationToken)
    {
        var thing = await _context.Things.FindAsync(request.Id);

        if (thing == null) return null;

        _context.Remove(thing);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the thing");

        return Result<Unit>.Success(Unit.Value);
    }
}