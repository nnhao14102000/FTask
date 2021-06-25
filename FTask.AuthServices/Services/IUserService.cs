using FTask.AuthDatabase.Models;
using System.Threading.Tasks;

namespace FTask.AuthServices.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
    }
}
