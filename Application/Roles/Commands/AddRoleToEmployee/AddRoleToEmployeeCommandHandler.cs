using Application.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles.Commands.AddRoleToEmployee;

public class AddRoleToEmployeeCommandHandler : IRequestHandler<AddRoleToEmployeeCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    

    public AddRoleToEmployeeCommandHandler(DataContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Result<Unit>> Handle(AddRoleToEmployeeCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FindAsync(request.RoleId);
        if (role == null) return Result<Unit>.Failure("There is no role with this id");

        var user = await _context.Employees
            .Where(i => i.Id.Equals(request.EmployeeId))
            .Include(u => u.User)
            .Select(u => u.User)
            .FirstOrDefaultAsync();
        if (user == null) return Result<Unit>.Failure("There is no user with this id");

        var result = await _userManager.AddToRoleAsync(user, role.Name);

        if (!result.Succeeded) return Result<Unit>.Failure("Failed to add role to employee");

        return Result<Unit>.Success(Unit.Value);
    }
}