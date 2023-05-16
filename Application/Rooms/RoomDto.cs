using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.Entities;

namespace Application.Rooms;

public class RoomDto : LookupRoomDto
{
    public DateTime? RepairDate { get; set; }
    [Range(0, 100)]
    public int? RoomRating { get; set; }
    public string? Remarks { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<Room, RoomDto>().ReverseMap();
    }
}