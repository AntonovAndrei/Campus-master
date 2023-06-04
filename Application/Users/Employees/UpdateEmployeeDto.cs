using Application.Users.CommonDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Employees;

public class UpdateEmployeeDto : UserDto
{
    public UpdateEmployeeDto()
    {
        ProfessionIds = new List<Guid>();
        CampusesIds = new List<Guid>();
    }
    public DateTime EmploymentDate { get; set; }
    public List<Guid> ProfessionIds { get; set; }
    public List<Guid> CampusesIds { get; set; }
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateEmployeeDto, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        profile.CreateMap<UpdateEmployeeDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName + " " + s.MiddleName));
    }
}