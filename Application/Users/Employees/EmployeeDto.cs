using Application.Campuses;
using Application.Common.Mappings;
using Application.Professions;
using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Employees;

public class EmployeeDto : UserDto
{
    public EmployeeDto()
    {
        Professions = new List<ProfessionDto>();
        Campuses = new List<LookupCampusDto>();
    }
    
    public DateTime EmploymentDate { get; set; }
    public List<ProfessionDto> Professions { get; set; }
    public List<LookupCampusDto> Campuses { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.FirstName, opt=> opt.MapFrom(s => s.User.FirstName))
            .ForMember(d => d.LastName, opt=> opt.MapFrom(s => s.User.LastName))
            .ForMember(d => d.MiddleName, opt=> opt.MapFrom(s => s.User.MiddleName))
            .ForMember(d => d.BirthDate, opt=> opt.MapFrom(s => s.User.BirthDate))
            .ForMember(d => d.PhotoId, opt=> opt.MapFrom(s => s.User.PhotoId))
            .ForMember(d => d.Email, opt=> opt.MapFrom(s => s.User.Email))
            .ForMember(d => d.PhoneNumber, opt=> opt.MapFrom(s => s.User.PhoneNumber))
            .ForMember(d => d.Passport, opt=> opt.MapFrom(s => s.User.Passport));
    }
}