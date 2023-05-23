using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Requests.Queries.ListById;

public class RequestCurrentResidentListQueryHandler : IRequestHandler<RequestCurrentResidentListQuery, Result<PagedList<RequestDto>>>
{
    private readonly CampusContext _context;
    private readonly IMapper _mapper;
    private readonly IUserAcessor _userAcessor;

    public RequestCurrentResidentListQueryHandler(CampusContext context, IMapper mapper, IUserAcessor userAcessor)
    {
        _context = context;
        _mapper = mapper;
        _userAcessor = userAcessor;
    }

    public async Task<Result<PagedList<RequestDto>>> Handle(RequestCurrentResidentListQuery request, CancellationToken token)
    {
        var residentId = await _context.Residents
            .Where(r => r.UserId.Equals(_userAcessor.GetUserId()))
            .Select(r => r.Id)
            .SingleOrDefaultAsync(token);
        var query = _context.Requests
            .Where(r => r.CreatorResidentId.Equals(residentId))
            .OrderBy(t => t.CreatedDate)
            .ProjectTo<RequestDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<RequestDto>>.Success(
            await PagedList<RequestDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}