using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class News : Entity
{
    public News()
    {
        PhotoIds = new HashSet<Photo>();
    }
    public DateTime CreateDate { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid MainPhotoId { get; set; }
    //public virtual Photo Photo { get; set; }
    //Employ
    public Guid CreatedEmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    
    public virtual ICollection<Photo> PhotoIds { get; set; }
}