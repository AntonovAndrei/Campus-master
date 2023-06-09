﻿using Domain.SharedKernel;

namespace Domain.Entities;

public class Violation : BaseEntity
{
    public string Description { get; set; }
    public DateTime IncidentDateTime { get; set; }
    public bool IsSpent { get; set; }

    public Guid ResidentId { get; set; }
    public virtual Resident Resident { get; set; }

    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
}