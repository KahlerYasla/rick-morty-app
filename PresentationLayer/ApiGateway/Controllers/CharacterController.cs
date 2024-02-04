using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.ApiGateway.Dtos;
using rick_morty_app.DataAccessLayer.Data;
using rick_morty_app.EntityLayer.Concrete;

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
        public ActionResult<GetAllCharactersResponsetDto> GetAllCharacters()
        {
            var characters = _characterService.GetAllCharacters().Result;

            List<Character> charactersL = _characterService.GetAllCharacters().Result.ToList();

            Console.WriteLine(charactersL[0].Episodes[0].EpisodeName);

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