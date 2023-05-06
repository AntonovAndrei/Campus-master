using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Residents;

public class CreateResidentDto : UserDto
{
    public DateTime GraduationDate { get; set; }
    public string? MothersFullName { get; set; }
    public string? MothersPhoneNumber { get; set; }
    public string? FathersFullName { get; set; }
    public string? FathersPhoneNumber { get; set; }
    public string Password { get; set; }
    public Guid CampusId { get; set; }
    public Guid RoomId { get; set; }
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<CreateResidentDto, Resident>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        profile.CreateMap<CreateResidentDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName + " " + s.MiddleName));
    }
}