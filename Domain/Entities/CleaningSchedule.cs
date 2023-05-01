using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class CleaningSchedule : Entity
{
    [Range(1, 50)]
    public int Floor { get; set; }
    public DateTime DateTime { get; set; }

    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
}