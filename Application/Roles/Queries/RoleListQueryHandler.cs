using Application.Common;
using Application.Common.Pagination;
using Application.Professions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles.Queries;

public class RoleListQueryHandler : IRequestHandler<RoleListQuery, Result<List<LookupRoleDto>>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RoleListQueryHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<List<LookupRoleDto>>> Handle(RoleListQuery request, CancellationToken token)
    {
        var query = await _context.Roles.OrderBy(t => t.Name)
            .ProjectTo<LookupRoleDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        return Result<List<LookupRoleDto>>.Success(query);
    }
}