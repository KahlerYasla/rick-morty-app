using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rick_morty_app.EntityLayer.Concrete
{
    [Table("user")]
    public class User : BaseEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }

        // Relationships --------------------------------------------------------
        [JsonPropertyName("favorite_characters")]
        public virtual List<Character> FavoriteCharacters { get; set; }

        // Constructors ----------------------------------------------------------
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            FavoriteCharacters = new List<Character>();
        }
    }
}
