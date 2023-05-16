using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Rooms.Commands.Update;

public class UpdateRoomCommandHandler: IRequestHandler<UpdateRoomCommand, Result<Unit>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public UpdateRoomCommandHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms.FindAsync(request.RoomDto.Id);

        if (room == null) return null;

        _mapper.Map(request.RoomDto, room);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update room");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}