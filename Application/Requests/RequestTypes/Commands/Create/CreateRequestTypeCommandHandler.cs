using Application.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Requests.RequestTypes.Commands.Create;

public class CreateRequestTypeCommandHandler: IRequestHandler<CreateRequestTypeCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateRequestTypeCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateRequestTypeCommand request, CancellationToken cancellationToken)
    {
        var requestType = new RequestType() {Name = request.RequestTypeDto.Name};
        _context.RequestTypes.Add(requestType);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add requestType");

        return Result<Guid>.Success(requestType.Id);
    }
}