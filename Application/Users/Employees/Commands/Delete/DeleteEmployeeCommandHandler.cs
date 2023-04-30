using Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Employees.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly ILogger<DeleteEmployeeCommandHandler> _logger;
    
    public DeleteEmployeeCommandHandler(DataContext context, ILogger<DeleteEmployeeCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .Where(i => i.Id == request.EmployeeId)
            .Include(u => u.User)
            .FirstOrDefaultAsync(cancellationToken);
        if(employee == null)
            return Result<Unit>.Failure("No employee with such id");

        employee.User.IsDeleted = true;

        var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;
        if(!isSuccess) Result<Unit>.Failure("Failing delete user");
        
        return Result<Unit>.Success(Unit.Value);
    }
}