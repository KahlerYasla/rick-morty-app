namespace rick_morty_app.Dtos
{
    public class FavoriteCharacterResponseDto
    {
        public string Name { get; set; }

        public FavoriteCharacterResponseDto(string name)
        {
            Name = name;
        }
    }
}