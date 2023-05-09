using Application.Common;
using Application.Common.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Requests.Queries.List;

public class RequestListQuery : IRequest<Result<PagedList<RequestDto>>>
{
    public PagingParams Params { get; set; }
}