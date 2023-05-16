using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.NewsFolder.Queries.List;

public class NewsListQueryHandler : IRequestHandler<NewsListQuery, Result<PagedList<NewsDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public NewsListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<NewsDto>>> Handle(NewsListQuery request, CancellationToken token)
    {
        var query = _context.News
            .OrderBy(n => n.CreateDate)
            .ProjectTo<NewsDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<NewsDto>>.Success(
            await PagedList<NewsDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}