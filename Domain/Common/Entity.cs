using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}