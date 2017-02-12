using System.Threading.Tasks;
using PgsBoard.Dtos;

namespace PgsBoard.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterUserDto registerUserDto);
        Task<bool> Login(LoginDto loginDto);
        void Logout();
    }
}