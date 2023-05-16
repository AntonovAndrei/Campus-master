using System.Reflection;
using Application.Common;
using Application.Common.Behaviors;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Things.Commands;
using Application.Things.Commands.Create;
using Application.Things.Queries;
using Application.Things.Queries.List;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddDbContext<CampusContext>(o =>
            o.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        services.AddControllers(opt =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        }).AddFluentValidation(config => 
        {
            config.RegisterValidatorsFromAssemblyContaining<CreateThingCommand>();
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "My API", 
                Version = "v1" 
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                In = ParameterLocation.Header, 
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey 
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { 
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer" 
                        } 
                    },
                    new string[] { } 
                } 
            });
        });
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
        services.AddOptions();
        services.AddMediatR(typeof(ListThingQuery).Assembly);
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblies(new[] {typeof(ListThingQuery).Assembly});
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(Result<object>).Assembly));
        });
        services.AddScoped<IPhotoAccessor, PhotoAccessor>();
        services.AddScoped<IUserAcessor, UserAccessor>();

        return services;
    } 
}