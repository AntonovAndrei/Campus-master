using Application.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Rooms.Commands.Create;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateRoomCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room();
        _mapper.Map(request.RoomDto, room);
        _context.Rooms.Add(room);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add room");

        return Result<Guid>.Success(room.Id);
    }
}