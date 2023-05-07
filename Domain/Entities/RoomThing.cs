using Domain.SharedKernel;

namespace Domain.Entities;

public class RoomThing : BaseEntity
{
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; }
    public Guid ThingId { get; set; }
    public virtual Thing Thing { get; set; }
    
    public int Count { get; set; }
}