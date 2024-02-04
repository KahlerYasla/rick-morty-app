using rick_morty_app.EntityLayer.Concrete;

namespace PresentationLayer.ApiGateway.Dtos
{
    public class GetAllCharactersRequestDto
    {
        required public List<Character> Characters { get; set; }

        public GetAllCharactersRequestDto(List<Character> characters)
        {
            Characters = characters;
        }
    }
}
