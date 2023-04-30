using Application.Common;
using Application.Users.Residents.Commands.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Residents.Commands.Delete;

public class DeleteResidentCommandHandler : IRequestHandler<DeleteResidentCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly ILogger<DeleteResidentCommandHandler> _logger;
    
    public DeleteResidentCommandHandler(DataContext context, ILogger<DeleteResidentCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<Unit>> Handle(DeleteResidentCommand request, CancellationToken cancellationToken)
    {
        var resident = await _context.Residents
            .Where(i => i.Id == request.ResidentId)
            .Include(u => u.User)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(resident == null)
            return Result<Unit>.Failure("No resident with such id");

        resident.User.IsDeleted = true;

        var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;
        if(!isSuccess) Result<Unit>.Failure("Failing delete user");
        
        return Result<Unit>.Success(Unit.Value);
    }
}