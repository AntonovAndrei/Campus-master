using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Campuses;

public class CampusDto : LookupCampusDto
{
    public string HtmlInfo { get; set; }
    public Address Address { get; set; }
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Campus, CampusDto>().ReverseMap();
    }
}