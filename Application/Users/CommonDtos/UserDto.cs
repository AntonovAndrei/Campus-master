using Application.Common.Mappings;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.CommonDtos;

public class UserDto : LookupUserDto
{
    public DateTime BirthDate { get; set; }
    public PassportDto Passport { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<UserDto, User>()
            .ReverseMap();
    }
}