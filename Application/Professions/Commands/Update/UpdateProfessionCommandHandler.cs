using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Professions.Commands.Update;

public class UpdateProfessionCommandHandler: IRequestHandler<UpdateProfessionCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UpdateProfessionCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateProfessionCommand request, CancellationToken cancellationToken)
    {
        var profession = await _context.Professions.FindAsync(request.ProfessionDto.Id);

        if (profession == null) return null;

        _mapper.Map(request.ProfessionDto, profession);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update profession");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}