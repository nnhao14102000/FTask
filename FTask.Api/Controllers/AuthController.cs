using FTask.AuthDatabase.Models;
using FTask.AuthServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// API version 1.0 | Authentication controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/auths")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        /// <summary>
        /// Constructor, inject User authentication service into AuthController
        /// </summary>
        /// <param name="userService"></param>
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// API version 1.0 | Register for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// API version 1.0 | Register for admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("admin-register")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterAdminAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result); // status code : 200
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");//Status code : 400
        }

        /// <summary>
        /// API version 1.0 | Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// API version 1.0 | Login with Google
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login-google")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GoogleLoginAsync([FromBody] ExternalAuthModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.GoogleExternalLoginAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some things going wrong...");
        }
    }
}

