using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Rooms.Queries.List;

public class GetRoomListQuery : IRequest<Result<PagedList<RoomDto>>>
{
    public PagingParams Params { get; set; }
}