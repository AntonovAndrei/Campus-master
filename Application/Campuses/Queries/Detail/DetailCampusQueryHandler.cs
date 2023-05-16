using Application.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Campuses.Queries.Detail;

public class DetailCampusQueryHandler : IRequestHandler<DetailCampusQuery, Result<CampusDto>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public DetailCampusQueryHandler(CampusContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<Result<CampusDto>> Handle(DetailCampusQuery request, CancellationToken cancellationToken)
    {
        return Result<CampusDto>.Success(
            await _context.Campuses
                .Where(i => i.Id == request.CampusId)
                .ProjectTo<CampusDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken)
        );
    }
}