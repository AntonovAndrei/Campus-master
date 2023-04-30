using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Things;

public class ThingDto : IMapWith<Thing>
{
    public Guid? Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Thing, ThingDto>().ReverseMap();
        profile.CreateMap<Thing, Thing>();
    }
}