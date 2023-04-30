using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Things.Commands.Update;

public class UpdateThingCommandHandler : IRequestHandler<UpdateThingCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UpdateThingCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateThingCommand request, CancellationToken cancellationToken)
    {
        var thing = await _context.Things.FindAsync(request.ThingDto.Id);

        if (thing == null) return null;

        _mapper.Map(request.ThingDto, thing);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update thing");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}