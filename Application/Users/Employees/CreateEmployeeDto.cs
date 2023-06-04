using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Employees;

public class CreateEmployeeDto : UpdateEmployeeDto
{
    public string Password { get; set; }
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEmployeeDto, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        profile.CreateMap<CreateEmployeeDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName + " " + s.MiddleName));
    }
}