using Application.Common.Mappings;
using Application.Professions;
using Application.Users.Employees;
using Application.Users.Residents;
using Domain.Entities;
using Domain.Enums;

namespace Application.Requests;

public class RequestDto : IMapWith<Request>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ClosedDate { get; set; }

    public Guid RequestStatusId { get; set; }
    public Guid? EmployeeId { get; set; }

    public virtual RequestStatus RequestStatus { get; set; }
    public virtual LookupEmployeeDto Employee { get; set; }
    public virtual ProfessionDto Profession { get; set; }
}