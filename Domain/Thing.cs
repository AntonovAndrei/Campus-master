namespace Domain;

public class Thing : Entity
{
    public Thing()
    {
        RoomThings = new HashSet<RoomThing>();
    }
    public string Name { get; set; }

    public virtual ICollection<RoomThing> RoomThings { get; set; }
}