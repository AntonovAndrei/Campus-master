using System.ComponentModel.DataAnnotations;
using Domain.SharedKernel;

namespace Domain.Entities;

public class CleaningSchedule : BaseEntity
{
    [Range(1, 50)]
    public int Floor { get; set; }
    public DateTime DateTime { get; set; }

    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
}