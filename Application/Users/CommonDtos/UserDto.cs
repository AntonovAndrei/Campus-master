using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Users.CommonDtos;

public class UserDto : LookupUserDto
{
    public DateTime BirthDate { get; set; }
    public PassportDto Passport { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<UserDto, User>()
            .ForMember(des => des.Passport,
                opt => opt.MapFrom(s => s.Passport))
            .ReverseMap();
    }
}