namespace rick_morty_app.EntityLayer
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DataStatus Status { get; set; }
    }
}