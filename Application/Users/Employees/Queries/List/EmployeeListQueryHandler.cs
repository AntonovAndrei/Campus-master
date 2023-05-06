using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Employees.Queries.List;

public class EmployeeListQueryHandler : IRequestHandler<EmployeeListQuery, Result<PagedList<EmployeeDto>>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeListQueryHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<EmployeeDto>>> Handle(EmployeeListQuery request, CancellationToken token)
    {
        var query = _context.Employees
            .AsNoTracking()
            .OrderBy(t => t.User.LastName)
            .Include(u => u.User)
                .ThenInclude(p => p.Passport)
            .Include(p => p.Professions)
            .Include(c => c.Campuses)
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<EmployeeDto>>.Success(
            await PagedList<EmployeeDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}