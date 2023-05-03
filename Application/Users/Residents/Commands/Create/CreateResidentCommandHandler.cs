using System.Data.Common;
using Application.Common;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Residents.Commands.Create;

public class CreateResidentCommandHandler : IRequestHandler<CreateResidentCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateResidentCommandHandler> _logger;

    public CreateResidentCommandHandler(UserManager<User> userManager, DataContext context, 
        IMapper mapper, ILogger<CreateResidentCommandHandler> logger, IPhotoAccessor photoAccessor)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Result<Guid>> Handle(CreateResidentCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.Users.AnyAsync(e => e.Email.Equals(request.ResidentDto.Email)))
            return Result<Guid>.Failure("Email taken");

        request.ResidentDto.Id = Guid.Empty;
        
        var user = _mapper.Map<User>(request.ResidentDto);
        var resident = _mapper.Map<Resident>(request.ResidentDto);
        user.Resident = resident;
        resident.User = user;
        user.UserName = user.Email;
        
        var campus = await _context.Campuses
            .Where(i => request.ResidentDto.CampusId.Equals(i.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if(campus == null)
            return Result<Guid>.Failure("No campus with such id");
        resident.Campus = campus;
        var room = await _context.Rooms
            .Where(i => request.ResidentDto.RoomId.Equals(i.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if(room != null)
            return Result<Guid>.Failure("No room with such id");
        resident.Room = room;

        if (request.ResidentDto.PhotoId != null)
        {
            var photo = await _context.Photos
                .Where(i => i.Id == request.ResidentDto.PhotoId)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(photo == null)
                return Result<Guid>.Failure("Incorrect photo id");

            user.PhotoId = request.ResidentDto.PhotoId;
            user.Photo = photo;
        }

        var userResult = await _userManager.CreateAsync(user, request.ResidentDto.Password);
        if (!userResult.Succeeded) return Result<Guid>.Failure("Problem creating user");
        
        return Result<Guid>.Success(resident.Id);
    }
}