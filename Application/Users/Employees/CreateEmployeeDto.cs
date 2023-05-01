using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Employees;

public class CreateEmployeeDto : UserDto
{
    public CreateEmployeeDto()
    {
        ProfessionIds = new List<Guid>();
        CampusesIds = new List<Guid>();
    }
    
    
    public string Password { get; set; }
    public DateTime EmploymentDate { get; set; }
    public List<Guid> ProfessionIds { get; set; }
    public List<Guid> CampusesIds { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEmployeeDto, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        profile.CreateMap<CreateEmployeeDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}