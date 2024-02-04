using rick_morty_app.EntityLayer.Concrete;

namespace PresentationLayer.ApiGateway.Dtos
{
    public class GetAllEpisodesResponseDto
    {
        required public List<Episode> Episodes { get; set; }

        public GetAllEpisodesResponseDto(List<Episode> episode)
        {
            Episodes = episode;
        }
    }
}
