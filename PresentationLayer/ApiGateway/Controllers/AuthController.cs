using BusinessLogicLayer.Abstract;
using CoreInfrastructureLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rick_morty_app.Dtos;

namespace rick_morty_app.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
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
        [HttpPost("generate-token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequestDto request)
        {
            string secretRaw = _configuration.GetSection("TokenOptions").Get<TokenOptions>()!.SecurityKey!;
            TimeSpan tokenExpiration = TimeSpan.FromDays(_configuration.GetSection("TokenOptions").Get<TokenOptions>()!.AccessTokenExpriation!);

            string tokenGeneratorResult = _authService.GenerateToken(request.Username, request.Email, secretRaw, tokenExpiration);

            if (tokenGeneratorResult == "Username or email cannot be null!")
            {
                return BadRequest(tokenGeneratorResult);
            }

            return Ok(tokenGeneratorResult);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDto request)
        {
            string registerResult = _authService.Register(request.Name, request.Email, request.Password);

            if (registerResult == "Username or email cannot be null!")
            {
                return BadRequest(registerResult);
            }

            return Ok(registerResult);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            bool loginResult = _authService.Authenticate(request.Name, request.Password);

            if (!loginResult)
            {
                return BadRequest("Username or password is incorrect!");
            }

            return Ok(loginResult);
        }
    }
}