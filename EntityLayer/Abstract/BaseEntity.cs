using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rick_morty_app.EntityLayer
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DataStatus DataStatus { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            DataStatus = DataStatus.Inserted;
        }
    }
}