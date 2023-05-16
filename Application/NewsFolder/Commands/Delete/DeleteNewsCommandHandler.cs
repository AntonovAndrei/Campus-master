using Application.Common;
using MediatR;
using Persistence;

namespace Application.NewsFolder.Commands.Delete;

public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Result<Unit>>
{
    private readonly CampusContext _context;

    public DeleteNewsCommandHandler(CampusContext context)
    {
        _context = context;
    }

    public async Task<Result<Unit>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _context.News.FindAsync(request.Id);

        if (news == null) return null;

        _context.Remove(news);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the news");

        return Result<Unit>.Success(Unit.Value);
    }
}