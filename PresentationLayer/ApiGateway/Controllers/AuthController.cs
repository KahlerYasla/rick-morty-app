using CoreInfrastructureLayer.Helpers;
using Microsoft.AspNetCore.Mvc;
using rick_morty_app.Dtos.requests;

namespace rick_morty_app.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AuthController()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [HttpPost("generate-token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequestDto request)
        {
            if (request.Username == null || request.Email == null) BadRequest("Username and password are required!");

            string secret = Configuration["Secret"]!; // Assuming you have IConfiguration injected into the controller
            string tokenGenerated = JwtTokenGenerator.GenerateToken(request.Username!, request.Email!, secret);

            return Ok(tokenGenerated);
        }
    }
}