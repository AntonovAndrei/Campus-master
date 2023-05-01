using Application.Common.Mappings;
using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Employees;

public class EmployeeDto : UserDto
{
    public EmployeeDto()
    {
        Professions = new List<string>();
        Campusess = new List<string>();
    }
    
    public DateTime EmploymentDate { get; set; }
    public List<string> Professions { get; set; }
    public List<string> Campusess { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.FirstName, opt=> opt.MapFrom(s => s.User.FirstName))
            .ForMember(d => d.LastName, opt=> opt.MapFrom(s => s.User.LastName))
            .ForMember(d => d.MiddleName, opt=> opt.MapFrom(s => s.User.MiddleName))
            .ForMember(d => d.BirthDate, opt=> opt.MapFrom(s => s.User.BirthDate))
            .ForMember(d => d.PhotoId, opt=> opt.MapFrom(s => s.User.PhotoId))
            .ForMember(d => d.Passport, opt=> opt.MapFrom(s => s.User.Passport));
    }
}