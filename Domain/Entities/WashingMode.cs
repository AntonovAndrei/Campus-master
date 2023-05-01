using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class WashingMode : Entity
{
    public WashingMode()
    {
        LaundryQueues = new HashSet<LaundryQueue>();
    }

    [MaxLength(64)]
    [Required]
    public string Name { get; set; }
    [Range(0, 256)]
    public int Duration { get; set; }

    public virtual ICollection<LaundryQueue> LaundryQueues { get; set; }
}