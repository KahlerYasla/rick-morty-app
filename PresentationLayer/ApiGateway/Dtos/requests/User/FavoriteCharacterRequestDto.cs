namespace rick_morty_app.Dtos
{
    public class FavoriteCharacterRequestDto
    {
        public string Name { get; set; }

        public FavoriteCharacterRequestDto(string name)
        {
            Name = name;
        }
    }
}