using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Campus : Entity
{
    public Campus()
    {
        Employees = new HashSet<Employee>();
        Residents = new HashSet<Resident>();
    }
    
    public string Name { get; set; }
    public string HtmlInfo { get; set; }
    public Address Address { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<Resident> Residents { get; set; }
}