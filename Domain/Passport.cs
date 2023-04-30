using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class Passport : Entity
{
    [StringLength(4)]
    public string PassportSeries { get; set; }
    [StringLength(6)]
    public string PassportNumber { get; set; }
    public string Gender { get; set; }
    public Address RegisteredPlace { get; set; }
    public string IssuedBy { get; set; }
    public string IssuedCode { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Address BirthPlace { get; set; }
    public virtual User User { get; set; }
}