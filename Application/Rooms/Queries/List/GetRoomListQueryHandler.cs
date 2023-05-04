using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Rooms.Queries.List;

public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, Result<PagedList<RoomDto>>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GetRoomListQueryHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<RoomDto>>> Handle(GetRoomListQuery request, CancellationToken token)
    {
        var query = _context.Rooms.OrderBy(t => t.Block)
            .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
            .AsQueryable();
        return Result<PagedList<RoomDto>>.Success(
            await PagedList<RoomDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}