using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Rooms;

public class LookupRoomDto : IMapWith<Room>
{
    public Guid? Id { get; set; }
    public int Block { get; set; }
    public string BlockCode { get; set; }
    
    public virtual void Mapping(Profile profile)
    {
        profile.CreateMap<Room, LookupRoomDto>();
    }
}