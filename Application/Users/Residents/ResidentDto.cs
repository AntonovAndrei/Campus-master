using Application.Campuses;
using Application.Rooms;
using Application.Users.CommonDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Residents;

public class ResidentDto : UserDto
{
    public LookupRoomDto Room { get; set; }
    public LookupCampusDto Campus { get; set; }
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Resident, ResidentDto>()
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