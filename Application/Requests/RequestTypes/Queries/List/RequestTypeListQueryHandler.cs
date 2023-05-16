using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Requests.RequestTypes.Queries.List;

public class RequestTypeListQueryHandler: IRequestHandler<RequestTypeListQuery, Result<PagedList<RequestTypeDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public RequestTypeListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<RequestTypeDto>>> Handle(RequestTypeListQuery request, CancellationToken token)
    {
        var query = _context.RequestTypes.OrderBy(t => t.Name)
            .ProjectTo<RequestTypeDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<RequestTypeDto>>.Success(
            await PagedList<RequestTypeDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}