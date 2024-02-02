namespace rick_morty_app.EntityLayer.Concrete
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        // Relationships
        public virtual List<Episode> Episodes { get; set; }

        public Character(string name, string status, string species, string type, string gender, string imageUrl)
        {
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            ImageUrl = imageUrl;
            Episodes = new List<Episode>();
        }
    }
}
