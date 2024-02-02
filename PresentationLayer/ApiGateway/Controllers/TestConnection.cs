using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace rick_morty_app.Controllers
{
    [ApiController]
    public class TestConnection : Controller
    {
        [AllowAnonymous]
        [HttpGet("/test")]
        public ActionResult<object> TEST()
        {
            string status = "Connection is successful.";
            return Ok(status);
        }

    }
}