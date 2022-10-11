using API.Model;
using Digiwallet.Businness.Abstarct;
using Digiwallet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("getuserbyid/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var result = await userService.Login(user);
            var responseModel = new ResponseModel<User>();
            if (result == null)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Giriş Başarısız";
                return Ok(responseModel);
            }

            result.Password = null;
            responseModel.IsSuccess = true;
            responseModel.Message = "Giriş başarılı";
            responseModel.Data = result;  

            return Ok(responseModel);
        }

        [HttpPost("register")]

        public  async Task<IActionResult> Register([FromBody]User user)
        {
            var passwordhash = PasswordHelper.HashPassword(user.UserPassword);
            user.Password = passwordhash;
            var result = await userService.Register(user);
            var responseModel = new ResponseModel<User>();
            if (result.Id == 0)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Kayıt Başarısız";
                return Ok(responseModel);
            }
            result.UserPassword = null;
            responseModel.IsSuccess = true;
            responseModel.Message = "Kayıt başarılı";
            responseModel.Data = result;

            return Ok(responseModel);
        }
    }
}
