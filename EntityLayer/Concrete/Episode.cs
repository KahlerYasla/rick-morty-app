using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rick_morty_app.EntityLayer.Concrete
{
    [Table("episode")]
    public class Episode : BaseEntity
    {
        [JsonPropertyName("name")]
        public string EpisodeName { get; set; }
        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }
        [JsonPropertyName("episode")]
        public string EpisodeCode { get; set; }

        // NotMapped properties ------------------------------------------------
        [NotMapped]
        private List<string> _characterIds;

        [NotMapped]
        [JsonPropertyName("characters")]
        public List<string> CharacterIds
        {
            get => _characterIds;
            set => _characterIds = value.Select(x => x.Split("/").Last()).ToList();
        }
        // Relationships --------------------------------------------------------
        [JsonPropertyName("characters_in_episode")]
        [Column("characters")]
        public virtual List<Character> Characters { get; set; }

        // Constructors ----------------------------------------------------------
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Episode()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _characterIds = new List<string>();
            Characters = new List<Character>();
        }

        public Episode(string episodeName, DateTime airDate, string episodeCode)
        {
            EpisodeName = episodeName;
            AirDate = airDate.ToString("yyyy-MM-dd");
            EpisodeCode = episodeCode;
            _characterIds = new List<string>();
            Characters = new List<Character>();
        }
    }
}
