﻿using Application.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Rooms.Commands.Create;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result<Guid>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public CreateRoomCommandHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var dbRoom = await _context.Rooms
            .Where(r => r.Block.Equals(request.RoomDto.Block)
                        && r.BlockCode.Equals(request.RoomDto.BlockCode))
            .SingleOrDefaultAsync(cancellationToken);
        if(dbRoom != null)
            return Result<Guid>.Failure("Such a room already exists");
        
        var room = new Room();
        _mapper.Map(request.RoomDto, room);
        _context.Rooms.Add(room);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add room");

        return Result<Guid>.Success(room.Id);
    }
}