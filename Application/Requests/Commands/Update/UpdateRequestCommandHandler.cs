using Application.Common;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Requests.Commands.Update;

public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UpdateRequestCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.Requests.FindAsync(request.CreateRequestDto.Id);
        if (req == null) return null;

        _mapper.Map(request.CreateRequestDto, req);
        var type = await _context.RequestTypes
            .Where(r => r.Id.Equals(request.CreateRequestDto.TypeId))
            .SingleOrDefaultAsync();
        if (type == null) return Result<Unit>.Failure("Failed to update request, request type not found");
        req.Type = type;
        
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update request");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}