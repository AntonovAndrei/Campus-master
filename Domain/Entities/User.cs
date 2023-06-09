using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            IsDeleted = false;
        }
        
        //имя
        public string FirstName { get; set; }
        //фамилия
        public string LastName { get; set; }
        //отчество
        public string? MiddleName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? PhotoId { get; set; }
        
        public bool IsDeleted { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Resident Resident { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Photo Photo { get; set; }
    }
}