using Domain.Common;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        //public string Url { get; set; }
        public string? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}