using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Professions;

public class ProfessionDto : IMapWith<Profession>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Profession, ProfessionDto>().ReverseMap();
        profile.CreateMap<Profession, Profession>();
    }
}