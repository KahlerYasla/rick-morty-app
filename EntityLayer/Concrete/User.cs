namespace rick_morty_app.EntityLayer.Concrete
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relationships
        public virtual List<Character> FavoriteCharacters { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            FavoriteCharacters = new List<Character>();
        }
    }
}
