using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Room : BaseEntity
{
    public Room()
    {
        RoomThings = new HashSet<RoomThing>();
        Residents = new HashSet<Resident>();
    }
    public int Block { get; set; }
    public string BlockCode { get; set; }
    public DateTime? RepairDate { get; set; }
    [Range(0, 10)]
    public int? RoomRating { get; set; }
    public string? Remarks { get; set; }

    public virtual ICollection<Resident> Residents { get; set; }
    public virtual ICollection<RoomThing> RoomThings { get; set; }
}