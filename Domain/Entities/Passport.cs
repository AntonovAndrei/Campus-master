using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.SharedKernel;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Passport : BaseEntity
{
    [StringLength(4)]
    public string PassportSeries { get; set; }
    [StringLength(6)]
    public string PassportNumber { get; set; }
    public Gender Gender { get; set; }
    public Address RegisteredPlace { get; set; }
    public string IssuedBy { get; set; }
    public string IssuedCode { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Address BirthPlace { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }
}