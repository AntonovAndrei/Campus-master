using Application.Common;
using MediatR;
using Persistence;

namespace Application.Professions.Commands.Delete;

public class DeleteProfessionCommandHandler: IRequestHandler<DeleteProfessionCommand, Result<Unit>>
{
    private readonly DataContext _context;

    public DeleteProfessionCommandHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteProfessionCommand request, CancellationToken cancellationToken)
    {
        var profession = await _context.Professions.FindAsync(request.Id);

        if (profession == null) return null;

        _context.Remove(profession);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the profession");

        return Result<Unit>.Success(Unit.Value);
    }
}