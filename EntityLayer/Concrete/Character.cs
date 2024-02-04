using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rick_morty_app.EntityLayer.Concrete
{
    [Table("character")]
    public class Character : BaseEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("species")]
        public string Species { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }

        // NotMapped properties ------------------------------------------------
        [NotMapped]
        private List<string> _episodeIds;

        [NotMapped]
        [JsonPropertyName("episode")]
        [Column("episode_ids")]
        public List<string> EpisodeIds
        {
            get => _episodeIds;
            set => _episodeIds = value.Select(x => x.Split("/").Last()).ToList();
        }

        // Relationships --------------------------------------------------------
        [JsonPropertyName("episodes")]
        public virtual List<Episode> Episodes { get; set; }

        // Constructors ----------------------------------------------------------
        public Character(string name, string status, string species, string type, string gender, string imageUrl)
        {
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            ImageUrl = imageUrl;
            _episodeIds = new List<string>();
            Episodes = new List<Episode>();
        }
    }
}
