using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.ApiGateway.Dtos;
using rick_morty_app.DataAccessLayer.Data;

namespace rick_morty_app.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
        }

        [HttpGet("get-all-characters")]
        public ActionResult<GetAllCharactersRequestDto> GetAllCharacters()
        {
            var characters = _characterService.GetAllCharacters().Result;

            return Ok(characters);
        }

        [HttpGet("update-db-from-real-api")]
        public ActionResult UpdateDbFromRealApi()
        {
            FetchDataFromOriginalApi.FetchAndWriteDataAsync().Wait();

            return Ok("Database updated from real API!");
        }
    }
}