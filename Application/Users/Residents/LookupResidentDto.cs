using Application.Users.CommonDtos;
using AutoMapper;
using Domain;

namespace Application.Users.Residents;

public class LookupResidentDto : LookupUserDto
{
    public string RoomName { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Resident, LookupResidentDto>();
    }
}