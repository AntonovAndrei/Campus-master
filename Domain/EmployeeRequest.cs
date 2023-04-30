using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class EmployeeRequest : Entity
{
    
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ClosedDate { get; set; }

    public Guid RequestStatusId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ResidentId { get; set; }

    public virtual RequestStatus RequestStatus { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Resident Resident { get; set; }
}