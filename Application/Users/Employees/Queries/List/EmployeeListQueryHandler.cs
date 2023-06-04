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
    private readonly CampusContext _context;
    private readonly IMapper _mapper;

    public EmployeeListQueryHandler(CampusContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<EmployeeDto>>> Handle(EmployeeListQuery request, CancellationToken token)
    {
        IQueryable<EmployeeDto> query;

        //Отрефакторить!
        if (request.Params.FullName != null && !request.Params.FullName.Equals(""))
        {
            query = _context.Employees
                .Where(e => e.User.FullName.ToLower().Contains(request.Params.FullName.ToLower()))
                .AsNoTracking()
                .OrderBy(t => t.User.LastName)
                .Include(u => u.User)
                .ThenInclude(p => p.Passport)
                .Include(p => p.Professions)
                .Include(c => c.Campuses)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
        }
        else
        {
            query = _context.Employees
                .AsNoTracking()
                .OrderBy(t => t.User.LastName)
                .Include(u => u.User)
                .ThenInclude(p => p.Passport)
                .Include(p => p.Professions)
                .Include(c => c.Campuses)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
        }
                
                
        return Result<PagedList<EmployeeDto>>.Success(
            await PagedList<EmployeeDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}