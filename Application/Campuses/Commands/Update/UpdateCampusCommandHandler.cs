using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Campuses.Commands.Update;

public class UpdateCampusCommandHandler: IRequestHandler<UpdateCampusCommand, Result<Unit>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public UpdateCampusCommandHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateCampusCommand request, CancellationToken cancellationToken)
    {
        var campus = await _context.Campuses.FindAsync(request.CampusDto.Id);

        if (campus == null) return null;

        _mapper.Map(request.CampusDto, campus);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update campus");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}