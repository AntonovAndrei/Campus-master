using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class LaundryQueue : Entity
{
    public DateTime StartDateTime { get; set; }

    public Guid ResidentId { get; set; }
    public Guid WashingModeId { get; set; }
    public virtual Resident Resident { get; set; }
    public virtual WashingMode WashingMode { get; set; }
}