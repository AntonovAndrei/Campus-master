using Microsoft.EntityFrameworkCore;

namespace Domain;

[Owned]
public class Address
{
    public string Country { get; set; }
    public string Town { get; set; }
    public string Street { get; set; }
    public int House { get; set; }
    public int? Corps { get; set; }
}