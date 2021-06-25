using FTask.AuthDatabase.Models;
using FTask.AuthServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FTask.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/auths")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        //api/auth/register
        [HttpPost("register")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result); // status code : 200
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");//Status code : 400
        }

        [HttpPost("login")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}

