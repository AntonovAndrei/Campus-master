using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Requests.Queries.ListById;

public class RequestCurrentResidentListQuery: IRequest<Result<PagedList<RequestDto>>>
{
    public PagingParams Params { get; set; }
}