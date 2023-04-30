using Microsoft.AspNetCore.Identity;

namespace Domain;

public class UserRole : IdentityRole<Guid>
{
    public UserRole() : base() { }
    public UserRole(string name, string description) : base(name)
    {
        this.Description = description;
    }
    public string? Description { get; set; }
}