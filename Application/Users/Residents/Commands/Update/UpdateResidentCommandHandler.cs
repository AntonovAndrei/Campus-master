using Application.Common;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users.Residents.Commands.Update;

public class UpdateResidentCommandHandler : IRequestHandler<UpdateResidentCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateResidentCommandHandler> _logger;

    public UpdateResidentCommandHandler(UserManager<User> userManager, DataContext context, 
        IMapper mapper, ILogger<UpdateResidentCommandHandler> logger)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Result<Unit>> Handle(UpdateResidentCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(x => x.Email.Equals(request.ResidentDto.Email))
            .FirstOrDefaultAsync(cancellationToken);
        var resident = await _context.Residents.FindAsync(request.ResidentDto.Id, cancellationToken);
        if(resident == null) return Result<Unit>.Failure("There is no resident with this id");
        
        var campus = await _context.Campuses
            .Where(i => request.ResidentDto.CampusId.Equals(i.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if(campus == null)
            return Result<Unit>.Failure("No campus with such id");
        resident.Campus = campus;
        
        var room = await _context.Rooms
            .Where(i => request.ResidentDto.RoomId.Equals(i.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if(room != null)
            return Result<Unit>.Failure("No room with such id");
        resident.Room = room;
        
        _mapper.Map(user, request.ResidentDto);
        _mapper.Map(resident, request.ResidentDto);
        
        var userResult = await _userManager.UpdateAsync(user);
        if (!userResult.Succeeded) return Result<Unit>.Failure("Problem updating user");

        return Result<Unit>.Success(Unit.Value);
    }
}