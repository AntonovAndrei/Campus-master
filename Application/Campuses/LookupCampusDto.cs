using Application.Common.Mappings;
using Application.Professions;
using AutoMapper;
using Domain.Entities;

namespace Application.Campuses;

public class LookupCampusDto : IMapWith<Campus>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    
    public virtual void Mapping(Profile profile)
    {
        profile.CreateMap<Campus, LookupCampusDto>();
    }
}