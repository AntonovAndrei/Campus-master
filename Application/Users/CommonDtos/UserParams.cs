using Application.Common.Pagination;

namespace Application.Users.CommonDtos;

public class UserParams : PagingParams
{
    public string? FullName { get; set; }
}