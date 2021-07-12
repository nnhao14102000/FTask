using FTask.AuthDatabase.Models;
using FTask.AuthServices.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FTask.AuthServices.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private JwtHandler _jwtHandler;

        public UserService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtHandler = jwtHandler;
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

            var token = await _jwtHandler.GenerateToken(user);

            return new UserManagerResponse
            {
                Message = token[0],
                IsSuccess = true,
                ExpireDate = DateTime.Parse(token[1])
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

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.User);
            }

            if (result.Succeeded)
            {
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

        public async Task<UserManagerResponse> RegisterAdminAsync(RegisterModel model)
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

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.Admin);
            }

            if (result.Succeeded)
            {
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

        public async Task<UserManagerResponse> GoogleExternalLoginAsync(ExternalAuthModel model)
        {
            var payload = _jwtHandler.PayloadInfo(model.IdToken);

            if (payload is null)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid google authentication.",
                    IsSuccess = false
                };
            }

            var info = new UserLoginInfo(model.Provider, payload.Sub, model.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload["email"].ToString());

                if (user is null)
                {
                    user = new IdentityUser()
                    {
                        Email = payload["email"].ToString(),
                        UserName = payload["email"].ToString()
                    };

                    var result = await _userManager.CreateAsync(user);

                    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    if (await _roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await _userManager.AddToRoleAsync(user, UserRoles.User);
                    }
                    await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        var token = await _jwtHandler.GenerateToken(user);
                        return new UserManagerResponse
                        {
                            Message = token[0],
                            IsSuccess = true,
                            ExpireDate = DateTime.Parse(token[1])
                        };
                    }
                }
            }
            else
            {
                await _userManager.AddLoginAsync(user, info);
                var token = await _jwtHandler.GenerateToken(user);
                return new UserManagerResponse
                {
                    Message = token[0],
                    IsSuccess = true,
                    ExpireDate = DateTime.Parse(token[1])
                };
            }

            return new UserManagerResponse
            {
                Message = "Invalid google authentication.",
                IsSuccess = false
            };
        }
    }
}
