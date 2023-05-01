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
        profile.CreateMap<CreateResidentDto, Resident>();
    }
}