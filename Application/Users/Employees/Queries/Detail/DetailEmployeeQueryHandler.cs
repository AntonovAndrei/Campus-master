using Application.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Employees.Queries.Detail;

public class DetailEmployeeQueryHandler : IRequestHandler<DetailEmployeeQuery, Result<EmployeeDto>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DetailEmployeeQueryHandler(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<Result<EmployeeDto>> Handle(DetailEmployeeQuery request, CancellationToken cancellationToken)
    {
        return Result<EmployeeDto>.Success(_mapper.Map<EmployeeDto>(
            await _context.Employees
                .AsNoTracking()
                .Where(i => i.Id == request.EmployeeId)
                .Include(u => u.User)
                    .ThenInclude(p => p.Passport)
                .Include(p => p.Professions)
                .Include(c => c.Campuses)
                .FirstOrDefaultAsync(cancellationToken))
        );
    }
}