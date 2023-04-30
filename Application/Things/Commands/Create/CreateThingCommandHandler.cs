using Application.Common;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Things.Commands.Create;

public class CreateThingCommandHandler: IRequestHandler<CreateThingCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateThingCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateThingCommand request, CancellationToken cancellationToken)
    {
        var thing = new Thing() {Name = request.ThingDto.Name};
        _context.Things.Add(thing);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add thing");

        return Result<Guid>.Success(thing.Id);
    }
}