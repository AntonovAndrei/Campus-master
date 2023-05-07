﻿using Domain.Enums;
using Domain.SharedKernel;

namespace Domain.Entities;

public class Request : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ClosedDate { get; set; }

    public Guid RequestStatusId { get; set; }
    public Guid ProfessionId { get; set; }
    public Guid ResidentId { get; set; }
    public Guid? EmployeeId { get; set; }

    public virtual RequestStatus RequestStatus { get; set; }
    public virtual Profession Profession { get; set; }
    public virtual Resident Resident { get; set; }
    public virtual Employee Employee { get; set; }
}