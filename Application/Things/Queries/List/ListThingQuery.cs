using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Things.Queries.List;

public class ListThingQuery : IRequest<Result<PagedList<ThingDto>>>
{
    public PagingParams Params { get; set; }
}