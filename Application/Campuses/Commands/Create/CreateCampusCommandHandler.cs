using Application.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Campuses.Commands.Create;

public class CreateCampusCommandHandler: IRequestHandler<CreateCampusCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateCampusCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateCampusCommand request, CancellationToken cancellationToken)
    {
        var campus = new Campus() {Name = request.CampusDto.Name};
        _context.Campuses.Add(campus);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add campus");

        return Result<Guid>.Success(campus.Id);
    }
}