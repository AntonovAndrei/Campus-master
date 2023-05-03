using Application.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Professions.Commands.Create;

public class CreateProfessionCommandHandler: IRequestHandler<CreateProfessionCommand, Result<Guid>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateProfessionCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateProfessionCommand request, CancellationToken cancellationToken)
    {
        var profession = new Profession() {Name = request.ProfessionDto.Name};
        _context.Professions.Add(profession);

        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Guid>.Failure("Failed to add profession");

        return Result<Guid>.Success(profession.Id);
    }
}