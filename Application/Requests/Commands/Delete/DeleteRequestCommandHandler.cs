using Application.Common;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Requests.Commands.Delete;

public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Result<Unit>>
{
    private readonly DataContext _context;

    public DeleteRequestCommandHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.Requests.FindAsync(request.Id);

        if (req == null) return null;

        _context.Remove(req);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the request");

        return Result<Unit>.Success(Unit.Value);
    }
}