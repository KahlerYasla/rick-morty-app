using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace rick_morty_app.Controllers
{
    [Route("api/episode/[controller]")]
    public class EpisodeController : Controller
    {
        private readonly ILogger<EpisodeController> _logger;

        public EpisodeController(ILogger<EpisodeController> logger)
        {
            _logger = logger;
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