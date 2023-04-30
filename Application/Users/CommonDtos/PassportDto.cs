using System.ComponentModel.DataAnnotations;
using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Users.CommonDtos;

public class PassportDto : IMapWith<Passport>
{
    public string PassportSeries { get; set; }
    public string PassportNumber { get; set; }
    public string Gender { get; set; }
    public Address RegisteredPlace { get; set; }
    public string IssuedBy { get; set; }
    public string IssuedCode { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Address BirthPlace { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Passport, PassportDto>()
            .ReverseMap();
    }
}