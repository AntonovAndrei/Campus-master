using Application.Common;
using MediatR;
using Persistence;

namespace Application.Campuses.Commands.Delete;

public class DeleteCampusCommandHandler: IRequestHandler<DeleteCampusCommand, Result<Unit>>
{
    private readonly CampusContext _context;

    public DeleteCampusCommandHandler(CampusContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteCampusCommand request, CancellationToken cancellationToken)
    {
        var campus = await _context.Campuses.FindAsync(request.Id);

        if (campus == null) return null;

        _context.Remove(campus);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the campus");

        return Result<Unit>.Success(Unit.Value);
    }
}