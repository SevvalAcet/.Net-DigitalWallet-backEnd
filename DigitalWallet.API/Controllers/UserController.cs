using Microsoft.AspNetCore.Mvc;

namespace Digiwallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("getir")]
        public string Get()
        {
            return "Deneme";
        }
    }
}
