using Domain.Common;

namespace Domain.Entities;

public class RoomThing : Entity
{
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; }
    public Guid ThingId { get; set; }
    public virtual Thing Thing { get; set; }
    
    public int Count { get; set; }
}