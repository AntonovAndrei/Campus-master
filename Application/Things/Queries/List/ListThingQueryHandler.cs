using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Things.Queries.List;

public class ListThingQueryHandler : IRequestHandler<ListThingQuery, Result<PagedList<ThingDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public ListThingQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<ThingDto>>> Handle(ListThingQuery request, CancellationToken token)
    {
        var query = _context.Things.OrderBy(t => t.Name)
            .ProjectTo<ThingDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<ThingDto>>.Success(
            await PagedList<ThingDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}