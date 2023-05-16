using Application.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles.Commands.DeleteRoleFromResident;

public class DeleteRoleFromResidentCommandHandler : IRequestHandler<DeleteRoleFromResidentCommand, Result<Unit>>
{
    private readonly CampusContext _context;
    private readonly UserManager<User> _userManager;
    

    public DeleteRoleFromResidentCommandHandler(CampusContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Result<Unit>> Handle(DeleteRoleFromResidentCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FindAsync(request.RoleId);
        if (role == null) return Result<Unit>.Failure("There is no role with this id");

        var user = await _context.Residents
            .Where(i => i.Id.Equals(request.ResidentId))
            .Include(u => u.User)
            .Select(u => u.User)
            .FirstOrDefaultAsync();
        if (user == null) return Result<Unit>.Failure("There is no user with this id");

        var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

        if (!result.Succeeded) return Result<Unit>.Failure("Failed to remove role from resident");

        return Result<Unit>.Success(Unit.Value);
    }
}