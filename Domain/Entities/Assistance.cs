using Domain.Common;

namespace Domain.Entities;

public class Assistance : BaseEntity
{
    public string Description { get; set; }
    public DateTime HelpDate { get; set; }

    public Guid EmployeeId { get; set; }
    public Guid ResidentId { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Resident Resident { get; set; }
}