using Application.Common;
using Application.Common.Pagination;
using Application.Users.CommonDtos;
using MediatR;

namespace Application.Users.Employees.Queries.List;

public class EmployeeListQuery : IRequest<Result<PagedList<EmployeeDto>>>
{
    public UserParams Params { get; set; }
}