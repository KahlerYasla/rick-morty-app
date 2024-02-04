using rick_morty_app.EntityLayer.Concrete;

namespace PresentationLayer.ApiGateway.Dtos
{
    public class GetAllCharactersResponsetDto
    {
        required public List<Character> Characters { get; set; }

        public GetAllCharactersResponsetDto(List<Character> characters)
        {
            Characters = characters;
        }
    }
}
