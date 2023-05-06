using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Users.Residents.Queries.List;

public class ResidentListQuery : IRequest<Result<PagedList<ResidentDto>>>
{
    public PagingParams Params { get; set; }
}