using Application.Common;
using MediatR;
using Persistence;

namespace Application.Requests.RequestTypes.Commands.Delete;

public class DeleteRequestTypeCommandHandler: IRequestHandler<DeleteRequestTypeCommand, Result<Unit>>
{
    private readonly CampusContext _context;

    public DeleteRequestTypeCommandHandler(CampusContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteRequestTypeCommand request, CancellationToken cancellationToken)
    {
        var requestType = await _context.RequestTypes.FindAsync(request.Id);

        if (requestType == null) return null;

        _context.Remove(requestType);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the requestType");

        return Result<Unit>.Success(Unit.Value);
    }
}