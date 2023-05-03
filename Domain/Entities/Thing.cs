using Domain.Common;

namespace Domain.Entities;

public class Thing : BaseEntity
{
    public Thing()
    {
        RoomThings = new HashSet<RoomThing>();
    }
    public string Name { get; set; }

    public virtual ICollection<RoomThing> RoomThings { get; set; }
}