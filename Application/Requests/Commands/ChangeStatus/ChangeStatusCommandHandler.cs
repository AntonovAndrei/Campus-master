﻿using Application.Common;
using AutoMapper;
using Domain.Events;
using MediatR;
using Persistence;

namespace Application.Requests.Commands.ChangeStatus;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Result<Unit>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public ChangeStatusCommandHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.Requests.FindAsync(request.RequestId, cancellationToken);
        if (req == null) return null;

        req.RequestStatus = request.RequestStatus;
            
        req.AddDomainEvent(new RequestStatusChangedEvent(req));

        var success = await _context.SaveChangesAsync(cancellationToken) > 0;
        if (!success) return Result<Unit>.Failure("Failed to request status change");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}