using System.Data.Common;
using Application.Common;
using Application.Common.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Employees.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
{
    private readonly CampusContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateEmployeeCommandHandler> _logger;

    public CreateEmployeeCommandHandler(UserManager<User> userManager, CampusContext context, 
        IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger, IPhotoAccessor photoAccessor)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.Users.AnyAsync(e => e.Email.Equals(request.EmployeeDto.Email)))
            return Result<Guid>.Failure("Email taken");

        var user = _mapper.Map<User>(request.EmployeeDto);
        var employee = _mapper.Map<Employee>(request.EmployeeDto);
        user.Employee = employee;
        employee.User = user;
        user.UserName = user.Email;
        
        var campuses = await _context.Campuses
            .Where(i => request.EmployeeDto.CampusesIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        if(campuses.Count != request.EmployeeDto.CampusesIds.Count)
            return Result<Guid>.Failure("There is an error in one or more campuses");
        employee.Campuses = campuses;
        var professions = await _context.Professions
            .Where(i => request.EmployeeDto.ProfessionIds.Contains(i.Id))
            .ToListAsync(cancellationToken);
        if(professions.Count != request.EmployeeDto.ProfessionIds.Count)
            return Result<Guid>.Failure("There is an error in one or more profession");
        employee.Professions = professions;

        if (request.EmployeeDto.PhotoId != null)
        {
            var photo = await _context.Photos
                .Where(i => i.Id == request.EmployeeDto.PhotoId)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(photo == null)
                return Result<Guid>.Failure("Incorrect photo id");

            user.PhotoId = request.EmployeeDto.PhotoId;
            user.Photo = photo;
        }

        var userResult = await _userManager.CreateAsync(user, request.EmployeeDto.Password);
        if (!userResult.Succeeded) 
            return Result<Guid>.Failure("Problem creating user");
        
        
        return Result<Guid>.Success(employee.Id);
    }
}