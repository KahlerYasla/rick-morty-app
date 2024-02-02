using BusinessLogicLayer.Abstract;
using CoreInfrastructureLayer.Helpers;
using CoreInfrastructureLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rick_morty_app.Dtos.requests;

namespace rick_morty_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _authService = authService;
            _logger = logger;
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        [AllowAnonymous]
        [HttpGet("ping")]
        public ActionResult<string> Pong()
        {
            return Ok("You can successfully access the address!");
        }

        [HttpPost("/generate-token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequestDto request)
        {
            if (request.Username == null || request.Email == null) BadRequest("Username and password are required!");

            string secretRaw = _configuration.GetSection("TokenOptions").Get<TokenOptions>()!.SecurityKey!;
            string tokenGenerated = JwtTokenGenerator.GenerateToken(request.Username!, request.Email!, secretRaw);

            return Ok(tokenGenerated);
        }
    }
}