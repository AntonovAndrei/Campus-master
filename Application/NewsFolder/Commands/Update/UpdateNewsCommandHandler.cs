using Application.Common;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.NewsFolder.Commands.Update;

public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Result<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UpdateNewsCommandHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _context.News.FindAsync(request.NewsDto.Id);

        if (news == null) return null;

        _mapper.Map(request.NewsDto, news);
            
        var success = await _context.SaveChangesAsync() > 0;
        if (!success) return Result<Unit>.Failure("Failed to update news");

        return Result<Unit>.Success(_mapper.Map<Unit>(Unit.Value));
    }
}