namespace Domain
{
    public class Photo : Entity
    {
        //public string Url { get; set; }
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}