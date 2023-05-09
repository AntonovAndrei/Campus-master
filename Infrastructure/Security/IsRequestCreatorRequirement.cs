﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security;

public class IsRequestCreatorRequirement : IAuthorizationRequirement
{
    
}

public class IsRequestCreatorRequirementHandler : AuthorizationHandler<IsRequestCreatorRequirement>
{
    private readonly DataContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public IsRequestCreatorRequirementHandler(DataContext dbContext, 
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsRequestCreatorRequirement requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Task.CompletedTask;

        var residentId = _dbContext.Residents
            .Where(r => r.UserId.Equals(userId))
            .Select(i => i.Id)
            .SingleOrDefault();
        //здесь может быть ошибка потом проверить
        if (residentId.Equals(Guid.Empty)) return Task.CompletedTask;
        
        var requestId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
            .SingleOrDefault(x => x.Key == "id").Value?.ToString());

        var request = _dbContext.Requests
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.CreatorResidentId.Equals(residentId) && r.Id.Equals(requestId))
            .Result;
        
        if (request != null) context.Succeed(requirement); 

        return Task.CompletedTask;
    }
}