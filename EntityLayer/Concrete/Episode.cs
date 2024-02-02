namespace rick_morty_app.EntityLayer.Concrete
{
    public class Episode : BaseEntity
    {
        public string EpisodeName { get; set; }
        public DateTime AirDate { get; set; }
        public string EpisodeCode { get; set; }

        // Relationships
        public virtual List<Character> Characters { get; set; }

        public Episode(string episodeName, DateTime airDate, string episodeCode)
        {
            EpisodeName = episodeName;
            AirDate = airDate;
            EpisodeCode = episodeCode;
            Characters = new List<Character>();
        }
    }
}
