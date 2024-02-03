using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rick_morty_app.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly ILogger<EpisodeController> _logger;
        private readonly IEpisodeService _episodeService;

        public EpisodeController(ILogger<EpisodeController> logger, IEpisodeService episodeService)
        {
            _episodeService = episodeService;
            _logger = logger;
        }


    }
}