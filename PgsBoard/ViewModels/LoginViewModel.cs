using PgsBoard.Dtos;

namespace PgsBoard.ViewModels
{
    public class LoginViewModel
    {
        public LoginDto LoginDto { get; set; }

        public LoginViewModel()
        {
            LoginDto = new LoginDto();
        }
    }
}