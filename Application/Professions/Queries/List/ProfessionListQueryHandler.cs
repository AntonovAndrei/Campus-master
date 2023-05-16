using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Professions.Queries.List;

public class ProfessionListQueryHandler: IRequestHandler<ProfessionListQuery, Result<PagedList<ProfessionDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public ProfessionListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<ProfessionDto>>> Handle(ProfessionListQuery request, CancellationToken token)
    {
        var query = _context.Professions.OrderBy(t => t.Name)
            .ProjectTo<ProfessionDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<ProfessionDto>>.Success(
            await PagedList<ProfessionDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}