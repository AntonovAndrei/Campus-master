using Application.Users.CommonDtos;
using AutoMapper;
using Domain;

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
            .ForMember(d => d.User.FirstName, opt=> opt.MapFrom(s => s.FirstName))
            .ForMember(d => d.User.LastName, opt=> opt.MapFrom(s => s.LastName))
            .ForMember(d => d.User.MiddleName, opt=> opt.MapFrom(s => s.MiddleName))
            .ForMember(d => d.User.BirthDate, opt=> opt.MapFrom(s => s.BirthDate))
            .ForMember(d => d.User.PhotoId, opt=> opt.MapFrom(s => s.PhotoId))
            .ForMember(d => d.User.Passport, opt=> opt.MapFrom(s => s.Passport));
    }
}