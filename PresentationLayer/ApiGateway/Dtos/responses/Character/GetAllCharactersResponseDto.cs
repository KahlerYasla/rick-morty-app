using rick_morty_app.EntityLayer.Concrete;

namespace PresentationLayer.ApiGateway.Dtos.Responses
{
    public class GetAllCharactersResponseDto
    {
        required public List<Character> Characters { get; set; }

        public GetAllCharactersResponseDto(List<Character> characters)
        {
            Characters = characters;
        }
    }
}
