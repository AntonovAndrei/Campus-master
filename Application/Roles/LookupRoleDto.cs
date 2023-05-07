using Application.Common.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Roles;

public class LookupRoleDto : IMapWith<IdentityRole>
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<IdentityRole, LookupRoleDto>();
    }
}