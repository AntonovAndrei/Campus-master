using Domain.SharedKernel;

namespace Domain.Entities;

public class Profession : BaseEntity
{
    public Profession()
    {
        Employees = new HashSet<Employee>();
        Requests = new HashSet<Request>();
    }

    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<Request> Requests { get; set; }   
}