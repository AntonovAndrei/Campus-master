using Application.Common;
using Application.Users.Employees.Commands.Create;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Employees.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

    public UpdateEmployeeCommandHandler(UserManager<User> userManager, DataContext context, 
        IMapper mapper, ILogger<UpdateEmployeeCommandHandler> logger)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<Result<Unit>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(x => x.Email.Equals(request.EmployeeDto.Email))
            .FirstOrDefaultAsync(cancellationToken);
        var employee = await _context.Employees.FindAsync(request.EmployeeDto.Id, cancellationToken);
        if(employee == null) return Result<Unit>.Failure("There is no employee with this id");
        
        var campuses = await _context.Campuses
            .Where(i => request.EmployeeDto.CampusesIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        employee.Campuses = campuses;
        var professions = await _context.Professions
            .Where(i => request.EmployeeDto.ProfessionIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        employee.Professions = professions;
        
        _mapper.Map(user, request.EmployeeDto);
        _mapper.Map(employee, request.EmployeeDto);
        
        using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var userResult = await _userManager.UpdateAsync(user);
                if (!userResult.Succeeded) return Result<Unit>.Failure("Problem updating user");
        
                _context.Employees.Update(employee);
                var empSaved = await _context.SaveChangesAsync(cancellationToken) > 0;
                if(!empSaved) 
                    return Result<Unit>.Failure("Problem updating employee");
                
                await transaction.CommitAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                _logger.LogError(ex.Message);
                return Result<Unit>.Failure("Employee updating failed");
            }
        }
        
        return Result<Unit>.Success(Unit.Value);
    }
}