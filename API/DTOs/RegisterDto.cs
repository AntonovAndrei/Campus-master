using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Password must be complex")]
    public string Password { get; set; }
    [RegularExpression("^[a-zA-Z.,()' -]+$", ErrorMessage = "First name of incorrect format")]
    [Required]
    public string FirstName { get; set; }
    [RegularExpression("^[a-zA-Z.,()' -]+$", ErrorMessage = "Last name of incorrect format")]
    [Required]
    public string LastName { get; set; }
    [RegularExpression("^[a-zA-Z.,()' -]+$", ErrorMessage = "Middle name of incorrect format")]
    [Required]
    public string MiddleName { get; set; }
    [Required]
    public DateTime? BirthDate { get; set; }
}