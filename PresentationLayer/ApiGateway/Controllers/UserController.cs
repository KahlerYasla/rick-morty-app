using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreInfrastructureLayer.Helpers;
using BusinessLogicLayer.Abstract.Internals;
using BusinessLogicLayer.Concrete.Internals;
using rick_morty_app.EntityLayer.Concrete;
using rick_morty_app.Dtos;

namespace rick_morty_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = UserManager.Instance;
        }

        [HttpGet("get-favourite-characters")]
        public ActionResult<FavoriteCharacterResponseDto> GetFavouriteCharacters()
        {
            // get the username from the token
            // Split for the token type and the token itself ex: Bearer welfklwekfw.wlefkwlekf.weklkfl243oweof
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1]);

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // get the favourite characters
            var favouriteCharacters = _userService.GetUserFavouriteCharactersByUserId(user.Id).Result;

            return Ok(favouriteCharacters);
        }

        [HttpPost("add-favourite-character")]
        public ActionResult AddFavouriteCharacter([FromBody] FavoriteCharacterRequestDto request)
        {
            // get the username from the token
            // Split for the token type and the token itself ex: Bearer welfklwekfw.wlefkwlekf.weklkfl243oweof
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1]);

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // add the favourite character
            _userService.AddFavouriteCharacterToUser(user.Id, request.Name);

            return Ok("Character added to favourites!");
        }

        [HttpPost("remove-favourite-character")]
        public ActionResult<Character> RemoveFavouriteCharacter([FromBody] Character character)
        {
            // get the username from the token
            // Split for the token type and the token itself ex: Bearer welfklwekfw.wlefkwlekf.weklkfl243oweof
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1]);

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // remove the favourite character
            _userService.RemoveFavouriteCharacterFromUser(user.Id, character.Name);

            return Ok("Character removed from favourites!");
        }
    }
}