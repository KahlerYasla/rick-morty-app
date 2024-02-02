namespace rick_morty_app.EntityLayer
{
    public abstract class BaseEntity
    {
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