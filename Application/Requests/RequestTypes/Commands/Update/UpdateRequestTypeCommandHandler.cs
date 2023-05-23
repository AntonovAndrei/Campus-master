using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Requests.RequestTypes.Commands.Update;

public class UpdateRequestTypeCommandHandler: IRequestHandler<UpdateRequestTypeCommand, Result<Unit>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public UpdateRequestTypeCommandHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateRequestTypeCommand request, CancellationToken cancellationToken)
    {
        var requestType = await _context.RequestTypes.FindAsync(request.RequestTypeDto.Id);

        if (requestType == null) return null;

        _mapper.Map(request.RequestTypeDto, requestType);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update requestType");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}