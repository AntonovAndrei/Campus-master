using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.Users.Employees.Queries.List;

public class EmployeeListQuery : IRequest<Result<PagedList<EmployeeDto>>>
{
    public PagingParams Params { get; set; }
}