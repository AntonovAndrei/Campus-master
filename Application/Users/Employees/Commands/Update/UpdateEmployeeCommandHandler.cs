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
            .Include(p => p.Passport)
            .FirstOrDefaultAsync(cancellationToken);
        if(user == null)
            return Result<Unit>.Failure("There is no employee with such email");
        var employee = await _context.Employees
            .Where(i => i.Id.Equals(request.EmployeeDto.Id))
            .Include(c => c.Campuses)
            .Include(p => p.Professions)
            .FirstOrDefaultAsync(cancellationToken);
        if(employee == null) return Result<Unit>.Failure("There is no employee with this id");

        var photo = await _context.Photos.FindAsync(request.EmployeeDto.PhotoId);
        if(photo.Equals(null))
            return Result<Unit>.Failure("There is no photo with such id"); 
        
        var newCampuses = await _context.Campuses
            .Where(i => request.EmployeeDto.CampusesIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        
        var newcCampIds = request.EmployeeDto.CampusesIds;
        var oldCampIds = employee.Campuses.Select(c => c.Id).ToList();
        
        var deletedCampuses = employee.Campuses.Where(i => oldCampIds.Except(newcCampIds).Contains(i.Id)).ToList();
        var addedCampuses = employee.Campuses.Where(i => newcCampIds.Except(oldCampIds).Contains(i.Id)).ToList();
        
        foreach (var d in deletedCampuses)
            employee.Campuses.Remove(d);
        foreach (var n in addedCampuses)
            employee.Campuses.Add(n);

        
        var dbProfessions = await _context.Professions
            .Where(i => request.EmployeeDto.ProfessionIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        
        var newcProfIds = request.EmployeeDto.ProfessionIds;
        var oldProfIds = employee.Professions.Select(c => c.Id).ToList();
        
        var deletedProfessions = employee.Professions.Where(i => oldProfIds.Except(newcProfIds).Contains(i.Id));
        var addedProfessions = employee.Professions.Where(i => newcProfIds.Except(oldProfIds).Contains(i.Id));
        
        foreach (var d in deletedProfessions)
            employee.Professions.Remove(d);
        foreach (var n in addedProfessions)
            employee.Professions.Add(n);
        
        
        _mapper.Map(request.EmployeeDto, user);
        _mapper.Map(request.EmployeeDto, employee);
        
        var userResult = await _userManager.UpdateAsync(user);
        if (!userResult.Succeeded) return Result<Unit>.Failure("Problem updating user");

        return Result<Unit>.Success(Unit.Value);
    }
}