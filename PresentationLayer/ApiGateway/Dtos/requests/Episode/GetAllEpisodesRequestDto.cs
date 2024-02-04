using rick_morty_app.EntityLayer.Concrete;

namespace PresentationLayer.ApiGateway.Dtos
{
    public class GetAllEpisodesRequestDto
    {
        required public List<Episode> Episodes { get; set; }

        public GetAllEpisodesRequestDto(List<Episode> episode)
        {
            Episodes = episode;
        }
    }
}
