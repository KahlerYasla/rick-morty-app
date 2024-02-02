using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace rick_morty_app.Controllers
{
    [Route("api/character/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
        }

        [HttpGet]
        [Route("/")]
        public ActionResult<string> Index()
        {
            return "You can successfully access the address!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}