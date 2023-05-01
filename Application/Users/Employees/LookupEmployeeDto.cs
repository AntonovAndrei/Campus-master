using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Employees;

public class LookupEmployeeDto : LookupUserDto
{
    public string Profession { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, LookupEmployeeDto>()
            .ForMember(d => d.FirstName, opt=> opt.MapFrom(s => s.User.FirstName))
            .ForMember(d => d.LastName, opt=> opt.MapFrom(s => s.User.LastName))
            .ForMember(d => d.MiddleName, opt=> opt.MapFrom(s => s.User.MiddleName))
            .ForMember(d => d.Email, opt=> opt.MapFrom(s => s.User.Email))
            .ForMember(d => d.PhotoId, opt=> opt.MapFrom(s => s.User.PhotoId))
            .ForMember(d => d.PhoneNumber, opt=> opt.MapFrom(s => s.User.PhoneNumber));
    }
}