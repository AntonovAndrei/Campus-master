using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Residents.Queries.List;

public class ResidentListQueryHandler : IRequestHandler<ResidentListQuery, Result<PagedList<ResidentDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public ResidentListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<ResidentDto>>> Handle(ResidentListQuery request, CancellationToken token)
    {
        var query = _context.Residents
            .AsNoTracking()
            .OrderBy(t => t.User.LastName)
            .Include(u => u.User)
                .ThenInclude(p => p.Passport)
            .Include(r => r.Room)
            .Include(c => c.Campus)
            .ProjectTo<ResidentDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<ResidentDto>>.Success(
            await PagedList<ResidentDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}