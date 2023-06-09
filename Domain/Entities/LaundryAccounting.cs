﻿using Domain.SharedKernel;

namespace Domain.Entities;

public class LaundryAccounting : BaseEntity
{
    public DateTime Date { get; set; }

    public Guid EmployeeId { get; set; }
    public Guid ResidentId { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Resident Resident { get; set; }
}