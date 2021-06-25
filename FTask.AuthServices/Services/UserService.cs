using FTask.AuthDatabase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FTask.AuthServices.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that email address!",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid password!",
                    IsSuccess = false
                };
            }

            var claim = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Jwt:Issuer"],
                audience: _configuration["Authentication:Jwt:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException("Register model is null....");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password!!!",
                    IsSuccess = false
                };
            }

            var identityUser = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                // TODO: Send a confirmation Email
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }
    }
}
