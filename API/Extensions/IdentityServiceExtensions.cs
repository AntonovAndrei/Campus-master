﻿using System.Text;
using API.Services;
using Application.Common.Policies;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                //opt.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddRoleStore<RoleStore<IdentityRole, CampusContext, string>>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<CampusContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                opt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context => 
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chat")))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        services.AddScoped<TokenService>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("MustBeRequestCreator",
                policy =>
                {
                    policy.Requirements.Add(new IsRequestCreatorRequirement());
                });
        });
        services.AddScoped<IAuthorizationHandler, IsRequestCreatorRequirementHandler>();

        return services;
    }
}