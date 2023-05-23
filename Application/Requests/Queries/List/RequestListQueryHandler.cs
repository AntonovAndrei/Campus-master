using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Requests.Queries.List;

public class RequestListQueryHandler: IRequestHandler<RequestListQuery, Result<PagedList<RequestDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public RequestListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<RequestDto>>> Handle(RequestListQuery request, CancellationToken token)
    {
        var query = _context.Requests
            .OrderBy(t => t.CreatedDate)
            .ProjectTo<RequestDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<RequestDto>>.Success(
            await PagedList<RequestDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}