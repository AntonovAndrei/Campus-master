using Domain.SharedKernel;

namespace Domain.Entities;

public class RequestType : BaseEntity
{
    public RequestType()
    {
        Responsible = new HashSet<Employee>();
        Requests = new HashSet<Request>();
    }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public virtual ICollection<Employee> Responsible { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
}