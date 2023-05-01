using Application.Common.Mappings;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.CommonDtos;

public class LookupUserDto : IMapWith<User>
{
    public Guid? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public Guid? PhotoId { get; set; }
    
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public virtual void Mapping(Profile profile)
    {
        profile.CreateMap<User, LookupUserDto>()
            .ForMember(d => d.PhotoId,
                opt => opt.MapFrom(u => u.Photo.Id));
    }
}