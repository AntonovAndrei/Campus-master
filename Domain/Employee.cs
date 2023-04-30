﻿namespace Domain;

public class Employee : Entity
{
    public Employee()
    {
        EmployeeRequests = new HashSet<EmployeeRequest>();
        Requests = new HashSet<Request>();
        CleaningSchedules = new HashSet<CleaningSchedule>();
        Violations = new HashSet<Violation>();
        Assistances = new HashSet<Assistance>();
        Campuses = new HashSet<Campus>();
        Professions = new HashSet<Profession>();
        News = new HashSet<News>();
    }
    public DateTime EmploymentDate { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual ICollection<Profession> Professions { get; set; }
    public virtual ICollection<Campus> Campuses { get; set; }
    public virtual ICollection<Assistance> Assistances { get; set; }
    public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<News> News { get; set; }
    public virtual ICollection<CleaningSchedule> CleaningSchedules { get; set; }
    public virtual ICollection<Violation> Violations { get; set; }
}