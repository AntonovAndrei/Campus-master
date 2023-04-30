using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Resident : Entity
{
    public Resident()
    {
        Requests = new HashSet<Request>();
        EmployeeRequests = new HashSet<EmployeeRequest>();
        LaundryQueues = new HashSet<LaundryQueue>();
        Violations = new HashSet<Violation>();
        Assistances = new HashSet<Assistance>();
    }

    public DateTime GraduationDate { get; set; }
    public string? MothersFullName { get; set; }
    public string? MothersPhoneNumber { get; set; }
    public string? FathersFullName { get; set; }
    public string? FathersPhoneNumber { get; set; }
    
    //при удалении проживающего также нужно проставить и это поле
    public bool IsLeftCampus { get; set; }
    //так как будет соответсвующая роль
    //public bool IsMemberStudentCouncil { get; set; }

    //информацию про комнату дублируеться, чтобы постоянно не обращатьсяко таблице комнат
    public string RoomName { get; set; }
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; }
    public Guid CampusId { get; set; }
    public virtual Campus Campus { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }

    
    public virtual ICollection<Assistance> Assistances { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
    public virtual ICollection<LaundryQueue> LaundryQueues { get; set; }
    public virtual ICollection<Violation> Violations { get; set; }
}