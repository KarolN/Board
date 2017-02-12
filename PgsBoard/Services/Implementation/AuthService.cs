using System.Threading.Tasks;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;
using PgsBoard.AuthInfrastructure;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;

namespace PgsBoard.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;

        public AuthService(ApplicationUserManager applicationUserManager,
                            ApplicationSignInManager applicationSignInManager)
        {
            _applicationUserManager = applicationUserManager;
            _applicationSignInManager = applicationSignInManager;
        }

        public async Task<bool> RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registerUserDto.Username,
                Email = registerUserDto.Email
            };
            var result = await _applicationUserManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                await _applicationSignInManager.SignInAsync(user, false, false);
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            var result = await _applicationSignInManager.PasswordSignInAsync(loginDto.Username,
                loginDto.Password, false, false);

            return result == SignInStatus.Success;
        }

        public void Logout()
        {
            _applicationSignInManager.AuthenticationManager.SignOut();
        }
    }
}