using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Requests.RequestTypes.Queries.List;

public class RequestTypeListQuery : IRequest<Result<PagedList<RequestTypeDto>>>
{
    public PagingParams Params { get; set; }
}