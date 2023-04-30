﻿using Application.Common;
using Application.Common.Pagination;
using MediatR;

namespace Application.NewsFolder.Queries.List;

public class GetNewsListQuery : IRequest<Result<PagedList<NewsDto>>>
{
    public PagingParams Params { get; set; }
}