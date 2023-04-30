﻿using Application.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Residents.Queries.Detail;

public class DetailResidentQueryHandler : IRequestHandler<DetailResidentQuery, Result<ResidentDto>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DetailResidentQueryHandler(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<Result<ResidentDto>> Handle(DetailResidentQuery request, CancellationToken cancellationToken)
    {
        return Result<ResidentDto>.Success(
            await _context.Employees
                .Where(i => i.Id == request.ResidentId)
                .Include(u => u.User)
                .ProjectTo<ResidentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken)
        );
    }
}