using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Professions.Queries.List;

public class GetProfessionListQuery : IRequest<Result<PagedList<ProfessionDto>>>
{
    public PagingParams Params { get; set; }
}