using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreInfrastructureLayer.Helpers;
using BusinessLogicLayer.Abstract.Internals;
using BusinessLogicLayer.Concrete.Internals;
using rick_morty_app.EntityLayer.Concrete;

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

        [HttpGet("/get-favourite-characters")]
        public ActionResult<Character> GetFavouriteCharacters()
        {
            // get the username from the token
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString());

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // get the favourite characters
            var favouriteCharacters = _userService.GetUserFavouriteCharactersByUserId(user.Id).Result;

            return Ok(favouriteCharacters);
        }

        [HttpPost("/add-favourite-character")]
        public ActionResult<Character> AddFavouriteCharacter([FromBody] Character character)
        {
            // get the username from the token
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString());

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // add the favourite character
            user.FavoriteCharacters.Add(character);
            _userService.UpdateUser(user);

            return Ok("Character added to favourites!");
        }

        [HttpPost("/remove-favourite-character")]
        public ActionResult<Character> RemoveFavouriteCharacter([FromBody] Character character)
        {
            // get the username from the token
            string username = JwtTokenResolver.GetUsernameFromToken(HttpContext.Request.Headers["Authorization"].ToString());

            // get the user id from the database using service
            User user = _userService.GetUserByEmail(username).Result;

            // remove the favourite character
            user.FavoriteCharacters.Remove(character);
            _userService.UpdateUser(user);

            return Ok("Character removed from favourites!");
        }
    }
}